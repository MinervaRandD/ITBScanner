using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Asi.Itb.Bll;

namespace Asi.Itb.UI 
{
	public class FormStack : CollectionBase 
    {
        private List<StackForm> stack = new List<StackForm>();

		public void Run() 
        {
            try
            {
                Application.Run(this.Top);
            }
            catch (Exception e)
            {
                string msg = string.Format("Following unexpected error occurred. Show detail?\r\n{0}", e.Message); 
                DialogResult res = MessageBox.Show(msg, "Unexpected Error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Yes)
                {
                    ExceptionDisplayForm frm = new ExceptionDisplayForm();
                    frm.exception = e;
                    frm.ShowDialog();
                }

                this.Stop();
            }
            finally
            {
                DatabaseManager.CloseConnection();
            }
                
		}

		public void Stop() 
        {
			// nicely destroy each Form
			foreach(StackForm sf in List) {
				sf.Dispose();
			}

			// clear the list to kill the message pump in Run()
			List.Clear();
		}

		public void Push(Type FormType, bool reload) 
        {
			// only allow 1 Push at a time to maintain cache and stack itegrity
            lock (this)
            {
                foreach (StackForm sf in List)
                {
                    if (sf.GetType().Name.Equals(FormType.Name))
                    {
                        // form is cached so display cached version
                        if (reload)
                        {
                            sf.LoadData();
                            sf.Populate();
                        }
                        sf.Show();

                        // add it to the stack
                        stack.Add(sf);

                        return;
                    }
                }

                // the Form wasn't cached, so create it
                StackForm form = Preload(FormType);

                // display it
                form.Show();

                // add a close event handler
                form.FormClosed += new FormClose(form_FormClosed);

                // add it to the stack
                stack.Add(form);
            }
		}

		public StackForm Preload(Type FormType) 
        {
			StackForm form = (StackForm)Activator.CreateInstance(FormType);

			// get data on a separate thread
			form.BeginLoadData();

			// build the form
			form.Initialize();

            form.EndLoadData();

			// now populate the controls with any retrieved data
			form.Populate();

			form.MinimizeBox = false;  // required to get close event on PPC!

			// add it to the cache
			List.Add(form);

			return form;
		}

		public void Pop(uint FormsToPop, bool reload) 
        {
			if(stack.Count < FormsToPop) {
				throw new Exception("You cannot Pop the entire stack!");
			}
            else if (stack.Count == FormsToPop)
            {
                Stop();
            }
            else
            {
                // remove from stack but not cache
                for (int i = 0; i < FormsToPop; i++)
                {
                    stack.RemoveAt(stack.Count - 1);
                }

                // find the last form in the stack
                StackForm sf = this.Top;
                if (sf != null)
                {
                    if (reload)
                    {
                        sf.LoadData();
                        sf.Populate();
                    }
                    // make it visible
                    sf.Visible = true;
                }
            }
		}

		private void form_FormClosed() {
			Pop(1, false);
		}

        /// <summary>
        /// StackForm at the top of stack.
        /// </summary>
        public StackForm Top
        {
            get
            {
                if (stack.Count > 0)
                {
                    return stack[stack.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }
	}
}
