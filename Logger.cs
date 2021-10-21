using System;
using System.Windows.Forms;

namespace MouseSimulator
{
    class Logger
    {
        public void write(TextBox tv, String message)
        {
            tv.AppendText(getEscapeCharacter(tv) + getTime() + message);
        }

        private String getTime()
        {
            return "[" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "] ";
        }

        private String getEscapeCharacter(TextBox tv)
        {
            switch (tv.Text)
            {
                case "":
                    return "";
                default:
                    return System.Environment.NewLine;
            }
        }
    }
}
