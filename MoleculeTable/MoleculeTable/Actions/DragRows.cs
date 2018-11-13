using System.Drawing;
using System.Windows.Forms;

namespace MoleculeTable.Actions
{
    public class DragRows
    {

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        public DataGridViewRow RowSender { get; set; }
        public DataGridViewRow ReceiverRow { get; set; }
        public void dataGridView_MouseMove(DataGridView dataGridView, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            if (dragBoxFromMouseDown != Rectangle.Empty &&
                !dragBoxFromMouseDown.Contains(e.X, e.Y))
            {
                dataGridView.DoDragDrop(
                    dataGridView.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
            }
        }
        public void dataGridView_MouseDown(DataGridView dataGridView, MouseEventArgs e)
        {
            rowIndexFromMouseDown = dataGridView.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                Size dragSize = SystemInformation.DragSize;

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - dragSize.Width / 2,
                                                               e.Y - dragSize.Height / 2),
                                                               dragSize);
            }
            else
                dragBoxFromMouseDown = Rectangle.Empty;
        }
        public void dataGridView_DragOver(DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        public void dataGridView_DragDrop(DataGridView dataGridView, DragEventArgs e)
        {
            Point clientPoint = dataGridView.PointToClient(new Point(e.X, e.Y));

            rowIndexOfItemUnderMouseToDrop =
                dataGridView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect != DragDropEffects.Move) return;
            RowSender = e.Data.GetData(
                typeof(DataGridViewRow)) as DataGridViewRow;
            ReceiverRow = dataGridView.Rows[rowIndexOfItemUnderMouseToDrop];
            if (rowIndexFromMouseDown < rowIndexOfItemUnderMouseToDrop)
            {
                dataGridView.Rows.RemoveAt(rowIndexFromMouseDown);
                dataGridView.Rows.RemoveAt(rowIndexOfItemUnderMouseToDrop - 1);
                dataGridView.Rows.Insert(rowIndexFromMouseDown, ReceiverRow);
                dataGridView.Rows.Insert(rowIndexOfItemUnderMouseToDrop, RowSender);
            }
            else if (rowIndexFromMouseDown > rowIndexOfItemUnderMouseToDrop)
            {
                dataGridView.Rows.RemoveAt(rowIndexOfItemUnderMouseToDrop);
                dataGridView.Rows.RemoveAt(rowIndexFromMouseDown - 1);
                dataGridView.Rows.Insert(rowIndexOfItemUnderMouseToDrop, RowSender);
                dataGridView.Rows.Insert(rowIndexFromMouseDown, ReceiverRow);
            }
        }
    }
}
