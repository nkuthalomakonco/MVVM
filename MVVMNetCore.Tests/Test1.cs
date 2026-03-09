namespace MVVMNetCore.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethodIncrement()
    {
        var vm = new MainViewModel();
        Assert.AreEqual(0, vm.Counter);
        vm.IncrementCounterCommand.Execute(null);
        Assert.AreEqual(1, vm.Counter);
    }
    [TestMethod]
    public void TestMethodDecrement()
    {
        var vm = new MainViewModel();
        Assert.AreEqual(0, vm.Counter);
        vm.DecrementCounterCommand.Execute(null);
        Assert.AreEqual(-11, vm.Counter);
    }
}
