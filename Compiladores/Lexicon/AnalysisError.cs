using System;
public class AnalysisError : Exception
{
    private int position;

    public AnalysisError(String msg, int position):base(msg)
    {
       

        this.position = position;
    }

    public AnalysisError(String msg):base(msg)
    {
        this.position = -1;
    }

    public int getPosition()
    {
        return position;
    }

    public String toString()
    {
        return base.ToString() + ", @ "+position;
    }
}
