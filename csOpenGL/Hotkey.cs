using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    public class Hotkey
    {

        private bool repeat;
        private List<Key> keys;

        public Hotkey(bool repeat)
        {
            this.repeat = repeat;
            keys = new List<Key>();
        }

        public Hotkey AddKey(Key k)
        {
            keys.Add(k);
            return this;
        }

        public bool IsDown()
        {
            foreach(Key k in keys)
            {
                if(repeat)
                {
                    if(now.IsKeyDown(k))
                    {
                        return true;
                    }
                }
                else
                {
                    if(now.IsKeyDown(k) && !prev.IsKeyDown(k))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Static update shit
        private static KeyboardState prev, now;


        public static void Type()
        {
            if (Globals.state.Name == "Type to insert a name" && now.IsAnyKeyDown)
            {
                Globals.state.Name = "";
            }
            if (now.IsKeyDown(Key.BackSpace) && !prev.IsKeyDown(Key.BackSpace))
            {
                Globals.state.Name = Globals.state.Name.Length > 0 ? Globals.state.Name.Substring(0, Globals.state.Name.Length - 1) : Globals.state.Name;
            }
            if (Globals.state.Name.Length < 3)
            {
                    for (int i = (int)Key.A; i <= (int)Key.Z; i++)
                    {
                        if (now.IsKeyDown((Key)i) && !prev.IsKeyDown((Key)i))
                        {
                            int offset = 0;
                            if (now.IsKeyDown(Key.ShiftLeft) || now.IsKeyDown(Key.ShiftRight))
                            {
                                offset = -32;
                            }
                            Globals.state.Name += (char)(i + 14 + offset);
                        }
                    }
                
                for (int i = (int)Key.Number0; i <= (int)Key.Number9; i++)
                {
                    if (now.IsKeyDown((Key)i) && !prev.IsKeyDown((Key)i))
                    {
                        Globals.state.Name += i - 109;
                    }
                }
                for (int i = (int)Key.Keypad0; i <= (int)Key.Keypad9; i++)
                {
                    if (now.IsKeyDown((Key)i) && !prev.IsKeyDown((Key)i))
                    {
                        Globals.state.Name += i - 67;
                    }
                }
            }
        }


        public static void Update(KeyboardState kstate)
        {
            prev = now;
            now = kstate;
        } 

    }
}
