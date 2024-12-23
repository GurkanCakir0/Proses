using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _243908353_Huseyin_Gurkan_CAKIR_Final_Projesi1
{
    class ProsesQ
    {
        public int data;
        public ProsesQ Next;
        public ProsesQ(int data)
        {
            this.data = data;
            this.Next = null;
        }
    }
    class Queue_L
    {
        ProsesQ Front;
        ProsesQ Rear;
        public Queue_L()
        {
            this.Front = null;
            this.Rear = null;
        }

        public void EnQueue (int data)
        {
            ProsesQ proses = new ProsesQ(data);
            if (Front == null)
            {
                Front = Rear = proses;
            }
            else
            {
                Rear.Next = proses;
                Rear = proses; 
            }
        }
        public int deQueue()
        {
            if (Front == null)
            {
                System.Windows.Forms.MessageBox.Show("Kuyruk Boş");
                return -1;
            }
            else
            {
                int data = Front.data;
                Front = Front.Next;
                return data;
            }
        }
        public void print()
        {
            if (Front == null)
            {
                System.Windows.Forms.MessageBox.Show("Kuyruk Boş");
            }
            else
            {
                ProsesQ temp = Front;
                while (temp != null)
                {
                    temp = temp.Next;
                }
            }
        }
    }

    class stack_l
    {
        ProsesQ top;
        public stack_l()
        {
            top = null;
        }

        public void push(int data)
        {
            ProsesQ nstack = new ProsesQ(data);
            if (top== null)
            {
                top = nstack;
            }
            else
            {
                nstack.Next = top;
                top = nstack;
            }
        }

        public int pop()
        {
            if (top == null)
            {
                return -1;
            }
            else
            {
                int sayi = top.data;
                top = top.Next;
                return sayi;
            }
        }

        public void print()
        {
            if (top == null)
            {
                System.Windows.Forms.MessageBox.Show("Boş");
            }
            else
            {
                ProsesQ temp = top;
                while (temp != null)
                {
                    temp = temp.Next;
                }
            }
        }
    }
}
