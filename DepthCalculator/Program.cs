var treeStruct = CreateStructure();
var depthOfStruct = CalculateDepth(treeStruct);
Console.WriteLine("Depth is {0}", depthOfStruct);

static Branch CreateStructure()
{
    var rootBranch = new Branch();
    // naming is c{depth}_{orderFromLeftToRight}
    // depth: 2
    var c2_1 = new Branch();
    var c2_2 = new Branch();
    rootBranch.AddBranch(c2_1, c2_2);

    // depth: 3
    var c3_1 = new Branch();
    var c3_2 = new Branch();
    var c3_3 = new Branch();
    var c3_4 = new Branch();
    c2_1.AddBranch(c3_1);
    c2_2.AddBranch(c3_2, c3_3, c3_4);

    // depth: 4
    var c4_1 = new Branch();
    var c4_2 = new Branch();
    var c4_3 = new Branch();
    c3_2.AddBranch(c4_1);
    c3_3.AddBranch(c4_2, c4_3);

    // depth: 5
    var c5_1 = new Branch();
    c4_2.AddBranch(c5_1);

    return rootBranch;
}

static int CalculateDepth(Branch rootBranch)
{
    var maxChildDepth = 0;
    foreach (var branch in rootBranch.Branches)
    {
        var depth = CalculateDepth(branch);
        if (depth > maxChildDepth)
            maxChildDepth = depth;
    }

    return maxChildDepth + 1;
}