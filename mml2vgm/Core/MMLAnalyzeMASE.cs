using musicDriverInterface;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;

namespace MASE
{

    public class MASEExtend
    {
        public const int eMaxTotalVolume = 1000;
        public const int eMaxTotalVelocity = 1000;
    }
    enum enmMMLTypeExtend
    {
        IntegrationVolume = enmMMLType.IDE + 1,  // @V
        IntegrationVolumeUp,
        IntegrationVolumeDown,
        Accentvelocity
    }
}

namespace Core
{
    public partial class MMLAnalyze
    {
        private void CommanderMASE(partWork pw, partPage page, char cmd)
        {
            MML mml = new MML();
            mml.line = pw.getLine(page);
            mml.column = page.pos.col + 1;// pw.getPos();

            //エイリアスのスタックが変化したかチェック,更新する

            int aliesCnt = page.pos.alies == null ? 0 : page.pos.alies.Length;
            if (aliesCnt != page.oldAliesCount
                || (
                        aliesCnt > 0
                        // 同じ位置のマクロに入りなおした場合、検知できないが動作には問題ないはず...
                        // ( [%BD]2 こんな感じにしてもループ脱出コマンドが間にはいる )
                        && page.pos.alies[0] != page.oldAlies
                    )
                )
            {

                //初っ端の場合は直前値に初期値をセット
                if (page.oldAlies == null)
                {
                    page.oldAlies = new LinePos();
                    page.oldAlies.aliesDepth = 0;
                }

#if DEBUG

                //参考 : マクロに入ったか、抜けたか、入りなおしたか判定する。
                int n = 0;
                if (page.pos.alies != null)
                {
                    if ((page.pos.alies.Length < 1 ? 0 : page.pos.alies[0].aliesDepth) > page.oldAlies.aliesDepth)
                    {
                        n = page.pos.alies[0].aliesDepth - page.oldAlies.aliesDepth;
                        Console.WriteLine("Push {0} times", n);
                    }
                    else if ((page.pos.alies.Length < 1 ? 0 : page.pos.alies[0].aliesDepth) == page.oldAlies.aliesDepth)
                    {
                        Console.WriteLine("Pop and Push");
                    }
                    else
                    {
                        n = page.oldAlies.aliesDepth - (page.pos.alies.Length < 1 ? 0 : page.pos.alies[0].aliesDepth);
                        Console.WriteLine("Pop {0} times", n);
                    }
                }
#endif

                //トレース情報の更新コマンドを発行
                MML mm = new MML();
                mm.type = enmMMLType.TraceUpdateStack;
                mm.line = pw.getLine(page);
                mm.column = page.pos.col + 1;
                mm.args = new List<object>();
                mm.args.Add(page.pos.alies);
                page.mmlData.Add(mm);

                //直前値を更新
                page.oldAliesCount = aliesCnt;
                if (page.pos.alies != null && page.pos.alies.Length > 0)
                {
                    LinePos.Move(page.pos.alies[0], page.oldAlies);
                }
                else
                {
                    LinePos.Clear(page.oldAlies);
                }
            }


            if (caretPoint.Y == mml.line.Lp.row)
            {
                if (!caretPointChannels.Contains(pw)) caretPointChannels.Add(pw);
            }

            if (!SkipFlg && (
                (caretPoint.Y == mml.line.Lp.row && caretPoint.X <= mml.line.Lp.col + mml.column - 1)
                || (caretPoint.Y < mml.line.Lp.row && caretPointChannels.Contains(pw))
                ))
            {

                MML m = new MML();
                m.type = enmMMLType.SkipPlay;
                m.line = pw.getLine(page);
                m.column = pw.getPos(page);
                page.mmlData.Add(m);
                SkipFlg = true;

            }

            //コマンド解析

            switch (cmd)
            {
                case ' ':
                case '\t':
                    pw.incPos(page);
                    break;
                case '!': // CompileSkip
                    pw.incPos(page);
                    if (pw.getChar(page) == '!')
                    {
                        log.Write("CompileSkip");
                        page.dataEnd = true;
                        mml.type = enmMMLType.CompileSkip;
                        mml.args = new List<object>();
                        mml.args.Add("compileEnd");
                    }
                    else
                    {
                        CmdAccentVolumeMASE(pw, page, mml);
                    }
                    break;
                case '@': // instrument
                    log.Write("instrument");
                    CmdInstrumentMASE(pw, page, mml);
                    break;
                case '>': // octave Up
                    log.Write("octave Up");
                    CmdOctaveUp(pw, page, mml);
                    break;
                case '<': // octave Down
                    log.Write("octave Down");
                    CmdOctaveDown(pw, page, mml);
                    break;
                case ']': // volume Up
                    log.Write(" volume Up");
                    CmdVolumeUDMASE(pw, page, mml);
                    break;
                case '[': // volume Down
                    log.Write("volume Down");
                    CmdVolumeUDMASE(pw, page, mml, true);
                    break;
                case '#': // length(clock)
                    log.Write("length(clock)");
                    CmdClockLength(pw, page, mml);
                    break;
                case '(': // repeat
                    log.Write("repeat [");
                    CmdRepeatStart(pw, page, mml);
                    break;
                case ')': // repeat
                    log.Write("repeat ]");
                    CmdRepeatEnd(pw, page, mml);
                    break;
                case '{': // renpu
                    log.Write("renpu {");
                    CmdRenpuStart(pw, page, mml);
                    break;
                case '}': // renpu
                    log.Write("renpu }");
                    CmdRenpuEnd(pw, page, mml);
                    break;
                case '/': // repeat
                    log.Write("repeat /");
                    CmdRepeatExit(pw, page, mml);
                    break;
                case '"':
                    log.Write("lylic");
                    CmdLyric(pw, page, mml);
                    break;
                case '_':
                    log.Write("bend");
                    CmdBend(pw, page, mml);
                    break;
                case '&':
                    log.Write("tie");
                    CmdTie(pw, page, mml);
                    break;
                case '^':
                    log.Write("upper note");
                    pw.incPos(page);
                    break;
                case '~':
                    log.Write("tie minus clock");
                    CmdTieMC(pw, page, mml);
                    break;


                case 'A': // Address shift
                    log.Write("Address shift / Arpeggio");
                    CmdAddressShiftArpeggio(pw, page, mml);
                    break;
                case 'C': //MIDI Ch / Command Arpeggio
                    log.Write("MIDI Ch / Command Arpeggio");
                    CmdMIDIChCommandArpeggio(pw, page, mml);
                    break;
                case 'D': // Detune / ダイレクトモード
                    log.Write("Detune / DirectMode");
                    CmdDetuneDirectMode(pw, page, mml);
                    break;
                case 'E': // envelope / extendChannel
                    log.Write("envelope / extendChannel");
                    CmdE(pw, page, mml);
                    break;
                case 'J': // Jump point
                    log.Write("Jump point");
                    CmdJump(pw, page, mml);
                    break;
                case 'K': // key shift
                    log.Write("key shift");
                    CmdKeyShift(pw, page, mml);
                    break;
                case 'l': // length
                    log.Write("length");
                    CmdLength(pw, page, mml);
                    break;
                case 'L': // loop point
                    log.Write(" loop point");
                    CmdLoop(pw, page, mml);
                    break;

                case 'H': // Midi Channel
                    log.Write("Midi Channel");
                    CmdMIDIChMASE(pw, page, mml);
                    break;

                case 'm': // pcm mode / pcm mapMode Sw
                    log.Write("pcm mode / pcm mapMode Sw");
                    CmdMode(pw, page, mml);
                    break;
                case 'M': // lfo
                    log.Write("lfo");
                    CmdLfo(pw, page, mml);
                    break;
                case 'o': // octave
                    log.Write("octave");
                    CmdOctave(pw, page, mml);
                    break;
                case 'p': // pan
                    log.Write(" pan");
                    CmdPan(pw, page, mml);
                    break;
                case 'P': // noise or tone mixer
                    log.Write("noise or tone mixer or phase reset");
                    CmdMixer(pw, page, mml);
                    break;
                case 'q': // gatetime
                    log.Write(" gatetime q");
                    CmdGatetime(pw, page, mml);
                    break;
                case 'Q': // gatetime
                    log.Write("gatetime Q");
                    CmdGatetime2(pw, page, mml);
                    break;
                case 's': // sus ON/OFF
                    log.Write("sus ON/OFF");
                    CmdSusOnOff(pw, page, mml);
                    break;
                case 'S': // lfo switch or system effect
                    log.Write(" lfo switch or system effect");
                    CmdLfoSwitchOrSystemEffect(pw, page, mml);
                    break;
                case 'T': // tempo
                    log.Write(" tempo");
                    CmdTempo(pw, page, mml);
                    break;
                case 'U': // velocity
                    log.Write("velocity");
                    CmdVelocity(pw, page, mml);
                    break;
                case 'v': // volume
                    log.Write("volume/Expression");
                    CmdVolume(pw, page, mml);
                    break;
                case 'V': // totalVolume(Adpcm-A / Rhythm) or volume Arpeggio
                    log.Write("totalVolume(Adpcm-A / Rhythm) or volume Arpeggio");
                    CmdTotalVolumeOrArpeggio(pw, page, mml);
                    break;
                case 'w': // noise
                    log.Write("noise");
                    CmdNoise(pw, page, mml);
                    break;
                case 'y': // y
                    log.Write(" y");
                    CmdY(pw, page, mml);
                    break;
                case 'X': // Effect
                    log.Write(" Effect");
                    CmdEffect(pw, page, mml);
                    break;
                case 'F'://Forced Fnum
                    log.Write("Forced Fnum");
                    CmdForcedFnum(pw, page, mml);
                    break;


                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'a':
                case 'b':
                    log.Write(string.Format("note {0}", cmd));
                    CmdNote(pw, page, cmd, mml, true);
                    break;
                case 'r':
                    log.Write("rest");
                    CmdRest(pw, page, mml);
                    break;
                case 'R':
                    log.Write("restNoWork");
                    CmdRestNoWork(pw, page, mml);
                    break;
                case ';':
                    log.Write("comment out");
                    CmdCommentout(pw, page, mml);
                    break;
                case '*':
                    log.Write("synchronous");
                    CmdSynchronous(pw, page, mml);
                    break;

                default:
                    msgBox.setErrMsg(string.Format(msg.get("E05000"), cmd), mml.line.Lp);
                    pw.incPos(page);
                    break;
            }

            //mmlコマンドの追加

            if (mml.type == enmMMLType.unknown) return;

            if (!mmlData.ContainsKey(page.PartName))//この処理無意味っぽい
            {//この処理無意味っぽい
                mmlData.Add(page.PartName, new List<MML>());//この処理無意味っぽい(mmlData使ってない)
            }//この処理無意味っぽい

            page.mmlData.Add(mml);

            if (swToneDoubler)
            {
                mml = new MML();
                mml.type = enmMMLType.ToneDoubler;
                mml.line = pw.getLine(page);
                mml.column = pw.getPos(page);
                page.mmlData.Add(mml);
                swToneDoubler = false;
            }
        }

        private void CmdAccentVolumeMASE(partWork pw, partPage page, MML mml)
        {
            int n;
            if (pw.getNum(page, out n))
            {
                page.m_Accentvelocity = Common.CheckRange(n, 0, MASE.MASEExtend.eMaxTotalVelocity);
            }
            mml.type = (enmMMLType)MASE.enmMMLTypeExtend.Accentvelocity;
            mml.args = new List<object>();
            mml.args.Add(page.m_Accentvelocity);
        }

        private void CmdVolumeUDMASE(partWork pw, partPage page, MML mml, bool downflag = false)
        {
            int n;
            pw.incPos(page);
            if (pw.getNum(page, out n))
            {
                page.m_VolumeUDStep = Common.CheckRange(n, 0, MASE.MASEExtend.eMaxTotalVolume);
            }
            if (!downflag)
            {
                mml.type = (enmMMLType)MASE.enmMMLTypeExtend.IntegrationVolumeUp;
            }
            else
            {
                mml.type = (enmMMLType)MASE.enmMMLTypeExtend.IntegrationVolumeDown;
            }
            mml.args = new List<object>();
            mml.args.Add(page.m_VolumeUDStep);
        }

        private void CmdMIDIChMASE(partWork pw, partPage page, MML mml)
        {
            int n = -1;

            pw.incPos(page);

            if (!pw.getNum(page, out n))
            {
                msgBox.setErrMsg(msg.get("E05055"), mml.line.Lp);
                return;
            }
            n = Common.CheckRange(n, 0, 15);

            mml.type = enmMMLType.MIDICh;
            mml.args = new List<object>();
            mml.args.Add(n);
        }
        private void CmdInstrumentMASE(partWork pw, partPage page, MML mml)
        {
            int n;
            pw.incPos(page);

            mml.type = enmMMLType.Instrument;
            mml.args = new List<object>();
            char a = pw.getChar(page);
            int maxrange = 4;
            switch (a)
            {
                case 'T':                    //@Tn
                    //tone doubler
                    mml.args.Add('T');
                    pw.incPos(page);
                    break;
                case 'E':                    //@En
                    //Envelope
                    mml.args.Add('E');
                    pw.incPos(page);
                    break;
                case 'I':                    //@In
                    //Instrument(プリセット音色)
                    mml.args.Add('I');
                    pw.incPos(page);
                    break;
                case 'N':                    //@Nn
                    //None(音色設定直前に何もしない)
                    mml.args.Add('N');
                    pw.incPos(page);
                    break;
                case 'R':                    //@Rn
                    //RR(音色設定直前にRR=15をセットする)
                    mml.args.Add('R');
                    pw.incPos(page);
                    break;
                case 'A':                    //@An
                    //All send(音色設定直前に消音向け音色をセットする)
                    mml.args.Add('A');
                    pw.incPos(page);
                    break;
                case 'W':                    //@Wn,n,n,n
                    //波形データ(OPNA2専用)
                    mml.args.Add('W');
                    pw.incPos(page);
                    break;
                case 'S':                    //@Sn
                    //SysEx(MIDI系専用)
                    mml.args.Add('S');
                    pw.incPos(page);
                    break;
                case 'v':                    //@vn
                    mml.type = enmMMLType.RelativeVolumeSetting;
                    pw.incPos(page);
                    break;
                case 'V':                    //@Vn
                    mml.type = (enmMMLType)MASE.enmMMLTypeExtend.IntegrationVolume;
                    pw.incPos(page);
                    maxrange = MASE.MASEExtend.eMaxTotalVolume;
                    break;

                default:                     //normal
                    mml.args.Add('n');
                    break;
            }

            //数値取得
            if (a != 'W')
            {
                if (!pw.getNum(page, out n))
                {
                    if (mml.type == enmMMLType.Instrument) msgBox.setErrMsg(msg.get("E05002"), mml.line.Lp);
                    else msgBox.setErrMsg(msg.get("E05003"), mml.line.Lp);
                    n = 0;
                }
                n = Common.CheckRange(n, 0, 0xffff);
                mml.args.Add(n);

                if (
                        (
                        pw.cpg.Type == enmChannelType.FMOPN
                        || pw.cpg.Type == enmChannelType.FMOPL
                        || pw.cpg.Type == enmChannelType.FMOPM
                        || pw.cpg.Type == enmChannelType.FMOPNex
                        )
                    && (
                        a == 'N'
                        || a == 'R'
                        || a == 'A'
                        || (mml.args[0] is char && (char)mml.args[0] == 'n')
                        )
                    )
                {
                    if (desVGM.instFM.ContainsKey(n))
                    {
                        mml.args.Add(desVGM.instFM[n].Item1);
                    }
                    else
                    {
                        msgBox.setErrMsg(msg.get("E05002"), mml.line.Lp);
                    }
                }

                return;
            }

            //数値複数取得
            while (true)
            {
                if (pw.getChar(page) == 'r')
                {
                    pw.incPos(page);
                    mml.args.Add("reset");
                }
                else if (pw.getNum(page, out n))
                {
                    n = Common.CheckRange(n, 0, maxrange);
                    mml.args.Add(n);
                }
                else
                {
                    mml.args.Add(null);
                }

                pw.skipTabSpace(page);

                if (pw.getChar(page) != ',') break;
                pw.incPos(page);
            }
        }
    }
}
