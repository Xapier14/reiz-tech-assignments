public class Branch
{
    private readonly List<Branch> _branches = new();
    public IList<Branch> Branches => _branches;

    public void AddBranch(params Branch[] branches)
        => _branches.AddRange(branches);
}