using GalaSoft.MvvmLight.Messaging;
using DropDownMenu.Base;

namespace DropDownMenu.Message
{
    public class ReloadMessage : MessageBase
    {
        public ReloadMessage(ViewModelBase vm)
        {
            Model = vm;
        }

        public ViewModelBase Model { get; }
    }
}
