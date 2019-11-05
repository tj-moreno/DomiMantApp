

namespace DomiMantApp.Behavior
{    
    using Xamarin.Forms;
    public class EmailsEntryBehavior: Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.Unfocused += UnFocused;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Unfocused -= UnFocused;
            base.OnDetachingFrom(entry);
        }

        private void UnFocused(object sender, FocusEventArgs args)
        {
            var r = ValidarEmailAsyc(((Entry)sender).Text);

            if (r==false)
            {                
                ((Entry)sender).TextColor = Color.Red;                
            }
            else
            {
                ((Entry)sender).TextColor = Color.Black;
            }

        }

        private static bool ValidarEmailAsyc(string value)
        {            
             System.Text.RegularExpressions.Regex automata = new System.Text.RegularExpressions.Regex(@"\A(\w+\.?\w*\@\w+\.)(com)\Z");
             return automata.IsMatch(value);                       
        }
    }
}
