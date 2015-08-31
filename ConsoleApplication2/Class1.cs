using System;
using System.Reflection;
using System.Text;

public abstract class Gate
{
  protected bool in1;
  protected bool in2;
  protected bool output;
  public void Set(bool first, bool second)
  {
    in1 = first;
    in2 = second;
  }
  public bool getIn1() { return in1; }
  public bool getIn2() { return in2; }
  public bool getOutput() { return output; }
  public string ToTable()
  {
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("Sample of " + this.Name() + " gate logic");
    sb.AppendLine("A  B  " + this.Name());
    bool[] opts = { true, false };

    foreach (bool choice1 in opts)
    {
      foreach (bool choice2 in opts)
      {
        this.Set(choice1, choice2);
        this.Latch();
        sb.AppendLine(Convert.ToInt16(this.in1) + "  " + Convert.ToInt16(this.in2) + "  " + Convert.ToInt16(this.output));
      }
    }

    return sb.ToString();
  }
  protected abstract string vName();
  protected abstract void vLatch();
  public void Latch()
  {
    vLatch();
  }

  public string Name()
  {
    return vName();
  }
}
  public class NandGate : Gate
  {
    protected override string vName()
    {
      return "NandGate";
    }
    protected override void vLatch()
    {
      if (in1 & in2) { output = false; }
      else { output = true; }
    }
  }

  public class OrGate : Gate
  {
    protected override string vName()
    {
      return "OrGate";
    }
    protected override void vLatch()
    {
      output = in1 | in2;
    }
  }
  public class XorGate : Gate
  {
    protected override string vName()
    {
      return "XorGate";
    }
    protected override void vLatch()
    {
      if (in1 == in2) { output = false; }
      else { output = true; }
    }
  }
  public class AndGate : NandGate
  {
    protected override string vName()
    {
      return "AndGate";
    }
    protected override void vLatch()
    {
      base.vLatch();
      output = !output;
    }
  }



