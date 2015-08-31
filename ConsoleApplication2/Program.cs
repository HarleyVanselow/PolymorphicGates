using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2;


namespace ConsoleApplication2
{
  class Program
  {
    static void Main(string[] args)
    {
      NandGate nand = new NandGate();
      AndGate and = new AndGate();
      OrGate or = new OrGate();
      XorGate xor = new XorGate();
      Gate[] gates = { nand, and, or, xor };
      foreach (Gate gate in gates)
      {
        Console.WriteLine(gate.ToTable());
      }

      NandGate nand3 = new NandGate();
      NandGate nand5 = new NandGate();
      AndGate and1 = new AndGate();
      AndGate and9 = new AndGate();
      AndGate and7 = new AndGate();
      OrGate or2 = new OrGate();
      OrGate or6 = new OrGate();
      OrGate or10 = new OrGate();
      XorGate xor4 = new XorGate();
      XorGate xor8 = new XorGate();
      StringBuilder sb = new StringBuilder();
      bool[] opts = { true, false };
      sb.AppendLine("A  B  C  D  O");
      foreach (bool A in opts)
      {
        foreach (bool B in opts)
        {
          foreach (bool C in opts)
          {
            foreach (bool D in opts)
            {
              and1.Set(A, A);
              and1.Latch();

              or2.Set(A, B);
              or2.Latch();

              nand3.Set(B, C);
              nand3.Latch();

              xor4.Set(C, nand3.getOutput());
              xor4.Latch();

              nand5.Set(and1.getOutput(), or2.getOutput());
              nand5.Latch();

              or6.Set(and1.getOutput(), nand5.getOutput());
              or6.Latch();

              and7.Set(or2.getOutput(), xor4.getOutput());
              and7.Latch();

              xor8.Set(D, xor4.getOutput());
              xor8.Latch();

              and9.Set(or6.getOutput(), and7.getOutput());
              and9.Latch();

              or10.Set(and9.getOutput(), xor8.getOutput());
              or10.Latch();

              sb.AppendLine(Convert.ToInt16(A) + "  " + Convert.ToInt16(B) + "  " + Convert.ToInt16(C) + "  " + Convert.ToInt16(D) + "  " + Convert.ToInt16(or10.getOutput()));
            }
          }
        }
      }
      Console.WriteLine(sb.ToString());

    }
  }
}
