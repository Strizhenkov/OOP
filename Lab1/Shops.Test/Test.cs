using Xunit;

namespace Shops.Test;

public class Test
{
    [Fact]
    public void OpenStoreTest()
    {
        var firstProduct = new Product("Cola", 50);
        var secondProduct = new Product("Apple", 30);
        var storeCatalog = new Catalog();
        storeCatalog.AddProduct(firstProduct, 100);
        storeCatalog.AddProduct(secondProduct, 30);
        var myStore = new Store(storeCatalog, "Shop", "Street №7");
        Assert.Equal("Store Shop is open on Street №7", myStore.StoreInformation());
    }

    [Fact]
    public void ChangePriceTest()
    {
        var firstProduct = new Product("Gold", 2000);
        var storeCatalog = new Catalog();
        storeCatalog.AddProduct(firstProduct, 1);
        var myStore = new Store(storeCatalog, "Shop", "House");
        Assert.Equal("Product 'Gold' is available in Shop in 1 for 2000", myStore.ProductInformation(firstProduct));
        myStore.ChangePriceInStoreCatalog(firstProduct, 5000);
        Assert.Equal("Product 'Gold' is available in Shop in 1 for 5000", myStore.ProductInformation(firstProduct));
    }

    [Fact]
    public void MakePurchase()
    {
        var firstProduct = new Product("Milk", 67);
        var secondProduct = new Product("Fish", 152);
        var storeCatalog = new Catalog();
        storeCatalog.AddProduct(firstProduct, 5);
        storeCatalog.AddProduct(secondProduct, 12);
        var myStore = new Store(storeCatalog, "Shop", "House");
        var myCart = new Cart();
        myCart.AddProductInCart(firstProduct, 3);
        myCart.AddProductInCart(secondProduct, 1);
        Assert.Equal("The purchase is successful!", myStore.MakePurchase(myCart, 5000));
        var friendCart = new Cart();
        friendCart.AddProductInCart(firstProduct, 2);
        Assert.Equal("Buyer have not enough cash!", myStore.MakePurchase(friendCart, 1));
        myCart.AddProductInCart(firstProduct, 1000);
        Assert.Equal("Not enough of some product in store catalog!", myStore.MakePurchase(myCart, 9999999));
    }
}