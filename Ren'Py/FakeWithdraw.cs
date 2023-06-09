using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ren_Py
{
    public class SaveUndoRedo
    {
        public bool UndoStaus { get; set; }
        public bool RedoStaus { get; set; }
        private List<SaveCommand> m_SaveUndo { get; set; }
        private List<SaveCommand> m_SaveRedo { get; set; }
        public SaveUndoRedo()
        {
            m_SaveUndo = new List<SaveCommand>();
            m_SaveRedo = new List<SaveCommand>();
        }
        public void Add(List<string> SaveSouceTran, List<ListViewItem> CurrentCacheItemsSource, int Count_T)
        {
            m_SaveRedo.Clear();
            m_SaveUndo.Add(new SaveCommand(SaveSouceTran, CurrentCacheItemsSource, Count_T));
            UndoStaus = true;
            RedoStaus = false;
        }
        public SaveCommand Undo(List<string> SaveSouceTran, List<ListViewItem> CurrentCacheItemsSource, int Count_T)
        {
            SaveCommand TempCommand = m_SaveUndo[m_SaveUndo.Count - 1];
            m_SaveRedo.Add(new SaveCommand(SaveSouceTran, CurrentCacheItemsSource, Count_T));
            m_SaveUndo.RemoveAt(m_SaveUndo.Count - 1);
            UndoStaus = m_SaveUndo.Count == 0 ? false : true; 
            RedoStaus = true;
            return TempCommand;
        }
        public SaveCommand Redo(List<string> SaveSouceTran, List<ListViewItem> CurrentCacheItemsSource, int Count_T)
        {
            SaveCommand TempCommand = m_SaveRedo[m_SaveRedo.Count - 1];
            m_SaveUndo.Add(new SaveCommand(SaveSouceTran, CurrentCacheItemsSource, Count_T));
            m_SaveRedo.RemoveAt(m_SaveRedo.Count - 1);
            UndoStaus = true;
            RedoStaus = m_SaveRedo.Count == 0 ? false : true;
            return TempCommand;
        }
    }
    public class SaveCommand
    {
        public int m_Count_T { get; set; }
        public List<string> m_SaveSouceTran { get; set; }
        public List<ListViewItem> m_CurrentCacheItemsSource { get; set; }
        public SaveCommand(List<string> SaveSouceTran, List<ListViewItem> CurrentCacheItemsSource, int Count_T)
        {
            m_Count_T = Count_T;
            m_SaveSouceTran = SaveSouceTran;
            m_CurrentCacheItemsSource = CurrentCacheItemsSource;
        }
    }

}
