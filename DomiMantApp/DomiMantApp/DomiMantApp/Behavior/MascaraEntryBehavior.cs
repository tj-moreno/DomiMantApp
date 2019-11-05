
namespace DomiMantApp.Behavior
{    
    using Xamarin.Forms;

    public class MascaraEntryBehavior:Behavior<Entry>
    {
        private string _mascara = "";
        public string Mascara {
            get => _mascara;
            set {
                _mascara = value;
            }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        
        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = ((Entry)sender);
            var value = entry.Text;

            if (!string.IsNullOrWhiteSpace(Mascara))
            {
                if (value.Length==_mascara.Length)                
                    entry.MaxLength = _mascara.Length;

                if ((args.OldTextValue==null) || (args.OldTextValue.Length<=args.NewTextValue.Length))
                {
                    for (int i = Mascara.Length; i >= Mascara.Length; i--)
                    {
                        if (Mascara[(value.Length-1)]!='0')
                        {
                            value = value.Insert((value.Length - 1), Mascara[(value.Length - 1)].ToString());
                        }
                    }

                    entry.Text = value;
                }                
            }
        }
    }
}
