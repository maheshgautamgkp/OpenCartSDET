using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using OpenCartSDET.Core;
using OpenCartSDET.Pages;

namespace OpenCartSDET.Tests
{
    public class CartTests : BaseTest
    {
        [Test]
        public async Task Add_Product_And_Validate_Total_Price()
        {
            var home = new HomePage(Page);
            var product = new ProductPage(Page);
            var cart = new CartPage(Page);

            await home.OpenFirstProductAsync();

            decimal unitPrice = await product.GetPriceAsync();
            int quantity = 2;

            await product.SetQuantityAsync(quantity);
            await product.AddToCartAsync();
            await product.GoToCartAsync();

            decimal expectedTotal = unitPrice * quantity;
            decimal actualTotal = await cart.GetTotalAsync();

            actualTotal.Should().Be(expectedTotal);
        }

        [Test]
        public async Task Remove_Product_From_Cart()
        {
            var home = new HomePage(Page);
            var product = new ProductPage(Page);
            var cart = new CartPage(Page);

            await home.OpenFirstProductAsync();
            await product.AddToCartAsync();
            await product.GoToCartAsync();
            await cart.RemoveProductAsync();

            var content = await Page.ContentAsync();
            content.Should().Contain("Your shopping cart is empty!");
        }
    }
}