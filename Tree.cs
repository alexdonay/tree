using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree
{
    public class Tree<T>
    {
        public Nodo<T>? Root;
        public Tree() { }
        public void AppendNodo(T value)
        {
            Nodo<T> newNodo = new(value);
            Nodo<T>? actNodo = this.Root;
            Nodo<T>? lastNodo = null;
            while (actNodo != null)
            {
                lastNodo = actNodo;
                if (actNodo.Greater(newNodo))
                {
                    actNodo = actNodo.Left;
                }
                else
                {
                    actNodo = actNodo.Right;
                }
            }
            if (lastNodo != null)
            {
                if (lastNodo.Greater(newNodo))
                {
                    lastNodo.Left = newNodo;
                }
                else
                {
                    lastNodo.Right = newNodo;
                }
            }
            else
            {
                this.Root = newNodo;
            }
        }
        public void AppenManyNodo(params T[] items)
        {
            foreach (T n in items)
            {
                AppendNodo(n);
            }
        }
        public void DeleteNodoByValue(T value)
        {
            Nodo<T>? tempNo = this.Root;
            Nodo<T>? father = null;
            while (tempNo != null && !tempNo.Value.Equals(value))
            {
                father = tempNo;
                if (((IComparable<T>)value).CompareTo(tempNo.Value) < 0)
                {
                    tempNo = tempNo.Left;
                }
                else
                {
                    tempNo = tempNo.Right;
                }
            }
            if (tempNo == null)
            {
                return;
            }
            if (father == null)
            {
                if (tempNo.Right == null)
                {
                    this.Root = tempNo.Left;
                }
                else if (tempNo.Left == null)
                {
                    this.Root = tempNo.Right;
                }
                else
                {
                    Nodo<T>? sucessor = tempNo.Right;
                    while (sucessor.Left != null)
                    {
                        sucessor = sucessor.Left;
                    }
                    sucessor.Left = tempNo.Left;
                    this.Root = tempNo.Right;
                }
            }
            else if (tempNo.Equals(father.Left))
            {
                if (tempNo.Right == null)
                {
                    father.Left = tempNo.Left;
                }
                else if (tempNo.Left == null)
                {
                    father.Left = tempNo.Right;
                }
                else
                {
                    Nodo<T>? sucessor = tempNo.Right;
                    while (sucessor.Left != null)
                    {
                        sucessor = sucessor.Left;
                    }
                    sucessor.Left = tempNo.Left;
                    father.Left = tempNo.Right;
                }
            }
            else
            {
                if (tempNo.Right == null)
                {
                    father.Right = tempNo.Left;
                }
                else if (tempNo.Left == null)
                {
                    father.Right = tempNo.Right;
                }
                else
                {
                    Nodo<T>? sucessor = tempNo.Right;
                    while (sucessor.Left != null)
                    {
                        sucessor = sucessor.Left;
                    }
                    sucessor.Left = tempNo.Left;
                    father.Right = tempNo.Right;
                }
            }
        }
        private void InOrderTraversal(Nodo<T>? nodo)
        {
            if (nodo != null)
            {
                InOrderTraversal(nodo.Left);
                Console.Write(nodo.Value.ToString() + ",");
                InOrderTraversal(nodo.Right);
            }
        }
        public string InOrderTransversal()
        {
            InOrderTraversal(Root);
            return "";
        }
        private void PostOrderTraversal(Nodo<T>? nodo)
        {
            if (nodo != null)
            {
                PostOrderTraversal(nodo.Right);
                Console.Write(nodo.Value.ToString() + ",");
                PostOrderTraversal(nodo.Left);
            }
        }
        public string PostOrderTraversal()
        {
            PostOrderTraversal(Root);
            return "";
        }
        private void PreOrderTraversal(Nodo<T>? nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Value.ToString() + ",");
                PreOrderTraversal(nodo.Left);
                PreOrderTraversal(nodo.Right);
            }
        }
        public string PreOrderTraversal()
        {
            PreOrderTraversal(Root);
            return "";
        }
        public int Weight()
        {
            return Weight(this.Root);
        }
        private int Weight(Nodo<T>? nodo)
        {
            if (nodo == null)
            {
                return -1;
            }
            int alturaEsquerda = Weight(nodo.Left);
            int alturaDireita = Weight(nodo.Right);
            return Math.Max(alturaEsquerda, alturaDireita) + 1;
        }
        public int GetNivel(T valor)
        {
            return GetNivel(this.Root, valor, 1);
        }
        private int GetNivel(Nodo<T>? nodo, T valor, int actNivel)
        {
            if (nodo == null)
            {
                return 0;
            }
            if (nodo.Value.Equals(valor))
            {
                return actNivel;
            }
            int rightNivel = GetNivel(nodo.Left, valor, actNivel + 1);
            if (rightNivel != 0)
            {
                return rightNivel; 
            }

            return GetNivel(nodo.Right, valor, actNivel + 1);
        }
    }
}
