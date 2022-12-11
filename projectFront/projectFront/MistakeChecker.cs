using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectFront
{
    public struct MistakeCallback
    {
        public bool isError;
        public string errorMessage;

        public MistakeCallback(bool b, string s)
        {
            this.isError = b;
            this.errorMessage = s;
        }
    }
    public class MistakeChecker
    {
        public MistakeCallback checkMistakesID(string text)
        {
            if (text == String.Empty)
            {
                return new MistakeCallback(false, "Кажется вы забыли запонить ID");

            }
            if (AllowedString(text))
            {
                return new MistakeCallback(false, "Проверьте ID");
            }
            else
                return new MistakeCallback(true, "ну... Вы молодец") ;
            
        }
        public bool AllowedString(string text)
        {
            string NOT_ALLOWED = "- *&?/\\";
            return NOT_ALLOWED.Any((x) => (text.Contains(x)));
        }


    }
}
