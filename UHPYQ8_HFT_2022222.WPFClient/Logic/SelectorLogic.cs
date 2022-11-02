using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHPYQ8_HFT_2022222.WPFClient.Logic
{
    public class SelectorLogic : ISelectorLogic
    {
        public void OpenGameEditor()
        {
            new GameEditorMainWindow().ShowDialog();
        }

        public void OpenPlatformEditor()
        {
            new PlatformEditorMainWindow().ShowDialog();
        }

        public void OpenPublisherEditor()
        {
            new PublisherEditorMainWindow().ShowDialog();
        }

    }
}
