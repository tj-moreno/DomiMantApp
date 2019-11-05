
namespace DomiMantApp.Behavior
{
    using Xamarin.Forms;
    
    public class RequeridoBehavior: Behavior
    {
        protected override void OnAttachedTo(BindableObject bindable)
        {
            bindable.PropertyChanged += Bindable_PropertyChanged;
            base.OnAttachedTo(bindable);
        }        

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            bindable.PropertyChanged -= Bindable_PropertyChanged;
            base.OnDetachingFrom(bindable);
        }

        private void Bindable_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (sender.GetType().Name)
            {
                case "Entry":
                    
                    break;
                default:
                    break;
            }
        }
    }    
}
