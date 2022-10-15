using System.Net;
using System.Numerics;
using Microsoft.VisualBasic;

namespace Shops;

public class Product
{
    private string _name;
    private int _price;

    public Product(string name, int price)
    {
        _name = name;
        _price = price;
    }

    public void NewProductPrice(int newPrice)
    {
        _price = newPrice;
    }

    public string Name()
    {
        return _name;
    }

    public int Price()
    {
        return _price;
    }
}

public class Catalog
{
    private Dictionary<string, int> _productAmount;
    private List<Product> _products;

    public Catalog()
    {
        _productAmount = new Dictionary<string, int>() { };
        _products = new List<Product>() { };
    }

    public void AddProduct(Product curProduct, int curAmount)
    {
        if (!_productAmount.ContainsKey(curProduct.Name()))
        {
            _products.Add(curProduct);
            _productAmount.Add(curProduct.Name(), curAmount);
        }
        else
        {
            _productAmount[curProduct.Name()] += curAmount;
        }
    }

    public void DeleteProduct(Product curProduct, int curAmount)
    {
        if (!_productAmount.ContainsKey(curProduct.Name()))
        {
            Console.Write("ERROR This product is not in catalog!\n");
        }
        else
        {
            if (_productAmount[curProduct.Name()] != curAmount)
            {
                _productAmount[curProduct.Name()] -= curAmount;
            }
            else
            {
                _productAmount.Remove(curProduct.Name());
                _products.Remove(curProduct);
            }
        }
    }

    public void ChangePrice(Product thisProduct, int newPrice)
    {
        thisProduct.NewProductPrice(newPrice);
    }

    public int Amount(string productName)
    {
        return _productAmount[productName];
    }

    public int Price(Product thisProduct)
    {
        return thisProduct.Price();
    }
}

public class Cart
{
    private List<Product> _products;
    private List<int> _amount;
    private int _score;

    public Cart()
    {
        _products = new List<Product>();
        _amount = new List<int>();
        _score = 0;
    }

    public void AddProductInCart(Product curProduct, int curAmount)
    {
        _products.Add(curProduct);
        _amount.Add(curAmount);
        _score += curProduct.Price() * curAmount;
    }

    public int Score()
    {
        return _score;
    }

    public List<Product> ProductsInCart()
    {
        return _products;
    }

    public int AmountOfThisProduct(Product curProduct)
    {
        return _amount[_products.IndexOf(curProduct)];
    }
}

public class Store
{
    private string _storeName;
    private string _storePlace;
    private Catalog _catalog;

    public Store(Catalog storeCatalog, string storeName, string storePlace)
    {
        _catalog = storeCatalog;
        _storePlace = storePlace;
        _storeName = storeName;
    }

    public string MakePurchase(Cart buyerCart, int buyerCash)
    {
        foreach (Product thisProduct in buyerCart.ProductsInCart())
        {
            if (_catalog.Amount(thisProduct.Name()) < buyerCart.AmountOfThisProduct(thisProduct))
            {
                return "Not enough of some product in store catalog!";
            }
        }

        if (buyerCash < buyerCart.Score())
        {
            return "Buyer have not enough cash!";
        }

        foreach (Product thisProduct in buyerCart.ProductsInCart())
        {
            _catalog.DeleteProduct(thisProduct, buyerCart.AmountOfThisProduct(thisProduct));
        }

        return "The purchase is successful!";
    }

    public void ChangePriceInStoreCatalog(Product thisProduct, int changePrice)
    {
        _catalog.ChangePrice(thisProduct, changePrice);
    }

    public string StoreInformation()
    {
        return "Store " + _storeName + " is open on " + _storePlace;
    }

    public string ProductInformation(Product thisProduct)
    {
        return "Product '" + thisProduct.Name() + "' available in " + _storeName + " in " + _catalog.Amount(thisProduct.Name()) + " for " + _catalog.Price(thisProduct);
    }
}