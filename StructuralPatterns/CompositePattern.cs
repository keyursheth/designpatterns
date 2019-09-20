using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns
{
    public class CompositePattern
    {
        public static void Main()
        {
            Console.WriteLine("I want a leaf");
            Tree leaf = new Leaf();
            Console.WriteLine(leaf.CommonOperation());

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("I want a branch");
            Tree branch = GetBranch();
            Console.WriteLine(branch.CommonOperation());

            Console.ReadLine();
        }

        public static Branch GetBranch()
        {
            Branch branch = new Branch();            

            branch.Add(new Leaf());
            branch.Add(new Leaf());

            Branch branch1 = new Branch();
            branch1.Add(new Leaf());
            branch.Add(branch1);

            return branch;
        }
    }

    public abstract class Tree
    {
        public virtual void Add(Tree compositeShape)
        { }

        public virtual void Remove(Tree compositeShape)
        { }

        public abstract string CommonOperation();
    }

    public class Leaf : Tree
    {
        public override string CommonOperation()
        {
            return "Leaf";
        }
    }

    public class Branch : Tree
    {
        private List<Tree> branches;

        public Branch()
        {
            branches = new List<Tree>();
        }
        public override string CommonOperation()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;

            sb.Append("Branch(");
            foreach (var branch in branches)
            {                
                sb.Append(branch.CommonOperation());
                if (i != this.branches.Count - 1)
                {
                    sb.Append("+");
                }

                i++;
            }

            sb.Append(")");
            return sb.ToString();
        }

        public override void Add(Tree tree)
        {
            branches.Add(tree);
        }

        public override void Remove(Tree tree)
        {
            branches.Remove(tree);
        }
    }
}
