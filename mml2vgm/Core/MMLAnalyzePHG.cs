using musicDriverInterface;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;

namespace Core
{
    public partial class MMLAnalyze
    {
        bool upperflag = false;
        private void CommanderPHG(partWork pw, partPage page, char cmd)
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
                    upperflag = false;
                    break;
                case '!': // CompileSkip
                    log.Write("CompileSkip");
                    page.dataEnd = true;
                    mml.type = enmMMLType.CompileSkip;
                    mml.args = new List<object>();
                    pw.incPos(page);
                    if (pw.getChar(page) == '!')
                        mml.args.Add("compileEnd");
                    else
                        mml.args.Add("partEnd");
                    upperflag = false;
                    break;
                case '@': // instrument
                    log.Write("instrument");
                    CmdInstrument(pw, page, mml);
                    upperflag = false;
                    break;
                case '>': // octave Up
                    log.Write("octave Up");
                    CmdOctaveUp(pw, page, mml);
                    upperflag = false;
                    break;
                case '<': // octave Down
                    log.Write("octave Down");
                    CmdOctaveDown(pw, page, mml);
                    upperflag = false;
                    break;
                case ')': // volume Up
                    log.Write(" volume Up");
                    CmdVolumeUp(pw, page, mml);
                    upperflag = false;
                    break;
                case '(': // volume Down
                    log.Write("volume Down");
                    CmdVolumeDown(pw, page, mml);
                    upperflag = false;
                    break;
                case '#': // length(clock)
                    log.Write("length(clock)");
                    CmdClockLength(pw, page, mml);
                    upperflag = false;
                    break;
                case '[': // repeat
                    log.Write("repeat [");
                    CmdRepeatStart(pw, page, mml);
                    upperflag = false;
                    break;
                case ']': // repeat
                    log.Write("repeat ]");
                    CmdRepeatEnd(pw, page, mml);
                    upperflag = false;
                    break;
                case '{': // renpu
                    log.Write("renpu {");
                    CmdRenpuStart(pw, page, mml);
                    upperflag = false;
                    break;
                case '}': // renpu
                    log.Write("renpu }");
                    CmdRenpuEnd(pw, page, mml);
                    upperflag = false;
                    break;
                case '/': // repeat
                    log.Write("repeat /");
                    CmdRepeatExit(pw, page, mml);
                    upperflag = false;
                    break;
                case '"':
                    log.Write("lylic");
                    CmdLyric(pw, page, mml);
                    upperflag = false;
                    break;
                case '_':
                    log.Write("bend");
                    CmdBend(pw, page, mml);
                    upperflag = false;
                    break;
                case '&':
                    log.Write("tie");
                    CmdTie(pw, page, mml);
                    upperflag = false;
                    break;
                case '^':
                    log.Write("tie plus clock");
                    CmdTiePC(pw, page, mml);
                    upperflag = false;
                    break;
                case '~':
                    log.Write("tie minus clock");
                    CmdTieMC(pw, page, mml);
                    upperflag = false;
                    break;


                case 'A': // Address shift
                    log.Write("Address shift / Arpeggio");
                    CmdAddressShiftArpeggio(pw, page, mml);
                    upperflag = false;
                    break;
                case 'C': //MIDI Ch / Command Arpeggio
                    log.Write("MIDI Ch / Command Arpeggio");
                    CmdMIDIChCommandArpeggio(pw, page, mml);
                    upperflag = false;
                    break;
                case 'D': // Detune / ダイレクトモード
                    log.Write("Detune / DirectMode");
                    CmdDetuneDirectMode(pw, page, mml);
                    upperflag = false;
                    break;
                case 'E': // envelope / extendChannel
                    log.Write("envelope / extendChannel");
                    CmdE(pw, page, mml);
                    upperflag = false;
                    break;
                case 'J': // Jump point
                    log.Write("Jump point");
                    CmdJump(pw, page, mml);
                    upperflag = false;
                    break;
                case 'K': // key shift
                    log.Write("key shift");
                    CmdKeyShift(pw, page, mml);
                    upperflag = false;
                    break;
                case 'l': // length
                    log.Write("length");
                    CmdLength(pw, page, mml);
                    upperflag = false;
                    break;
                case 'L': // loop point
                    log.Write(" loop point");
                    CmdLoop(pw, page, mml);
                    upperflag = false;
                    break;
                case 'm': // pcm mode / pcm mapMode Sw
                    log.Write("pcm mode / pcm mapMode Sw");
                    CmdMode(pw, page, mml);
                    upperflag = false;
                    break;
                case 'M': // lfo
                    log.Write("lfo");
                    CmdLfo(pw, page, mml);
                    upperflag = false;
                    break;
                case 'o': // octave
                    log.Write("octave");
                    CmdOctave(pw, page, mml);
                    upperflag = false;
                    break;
                case 'p': // pan
                    log.Write(" pan");
                    CmdPan(pw, page, mml);
                    upperflag = false;
                    break;
                case 'P': // noise or tone mixer
                    log.Write("noise or tone mixer or phase reset");
                    CmdMixer(pw, page, mml);
                    upperflag = false;
                    break;
                case 'q': // gatetime
                    log.Write(" gatetime q");
                    CmdGatetime(pw, page, mml);
                    upperflag = false;
                    break;
                case 'Q': // gatetime
                    log.Write("gatetime Q");
                    CmdGatetime2(pw, page, mml);
                    upperflag = false;
                    break;
                case 's': // sus ON/OFF
                    log.Write("sus ON/OFF");
                    CmdSusOnOff(pw, page, mml);
                    upperflag = false;
                    break;
                case 'S': // lfo switch or system effect
                    log.Write(" lfo switch or system effect");
                    CmdLfoSwitchOrSystemEffect(pw, page, mml);
                    upperflag = false;
                    break;
                case 'T': // tempo
                    log.Write(" tempo");
                    CmdTempo(pw, page, mml);
                    upperflag = false;
                    break;
                case 'U': // velocity
                    log.Write("velocity");
                    CmdVelocity(pw, page, mml);
                    upperflag = false;
                    break;
                case 'v': // volume
                    log.Write("volume");
                    CmdVolume(pw, page, mml);
                    upperflag = false;
                    break;
                case 'V': // totalVolume(Adpcm-A / Rhythm) or volume Arpeggio
                    log.Write("totalVolume(Adpcm-A / Rhythm) or volume Arpeggio");
                    CmdTotalVolumeOrArpeggio(pw, page, mml);
                    upperflag = false;
                    break;
                case 'w': // noise
                    log.Write("noise");
                    CmdNoise(pw, page, mml);
                    upperflag = false;
                    break;
                case 'y': // y
                    log.Write(" y");
                    CmdY(pw, page, mml);
                    upperflag = false;
                    break;
                case 'X': // Effect
                    log.Write(" Effect");
                    CmdEffect(pw, page, mml);
                    upperflag = false;
                    break;
                case 'F'://Forced Fnum
                    log.Write("Forced Fnum");
                    CmdForcedFnum(pw, page, mml);
                    upperflag = false;
                    break;


                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'a':
                case 'b':
                    log.Write(string.Format("note {0}", cmd));
                    CmdNote(pw, page, cmd, mml, upperflag);
                    upperflag = false;
                    break;
                case 'r':
                    log.Write("rest");
                    CmdRest(pw, page, mml);
                    upperflag = false;
                    break;
                case 'R':
                    log.Write("restNoWork");
                    CmdRestNoWork(pw, page, mml);
                    upperflag = false;
                    break;
                case ';':
                    log.Write("comment out");
                    CmdCommentout(pw, page, mml);
                    upperflag = false;
                    break;
                case '*':
                    log.Write("synchronous");
                    CmdSynchronous(pw, page, mml);
                    upperflag = false;
                    break;

                default:
                    msgBox.setErrMsg(string.Format(msg.get("E05000"), cmd), mml.line.Lp);
                    pw.incPos(page);
                    upperflag = false;
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

    }
}
