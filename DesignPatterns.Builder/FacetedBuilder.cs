using System;

namespace DesignPatterns.Builder
{
    public class User
    {
        public string StreetAddress, Postcode, City;

        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}," +
                $" {nameof(Postcode)}: {Postcode}," +
                $" {nameof(City)}: {City}," +
                $" {nameof(CompanyName)}: {CompanyName}," +
                $" {nameof(Position)}: {Position}," +
                $" {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class UserBuilder //facade
    {
        //reference
        protected User user = new User();

        public UserJobBuilder Works => new UserJobBuilder(user);
        public UserAddressBuilder Lives => new UserAddressBuilder(user);

        public static implicit operator User(UserBuilder ub)
        {
            return ub.user;
        }
    }

    public class UserJobBuilder : UserBuilder
    {
        public UserJobBuilder(User user)
        {
            this.user = user;
        }

        public UserJobBuilder At(string companyName)
        {
            user.CompanyName = companyName;
            return this;
        }
        public UserJobBuilder AsA(string position)
        {
            user.Position = position;
            return this;
        }
        public UserJobBuilder Earning(int amount)
        {
            user.AnnualIncome = amount;
            return this;
        }
    }
    public class UserAddressBuilder : UserBuilder
    {
        public UserAddressBuilder(User user)
        {
            this.user = user;
        }

        public UserAddressBuilder At(string streetAddress)
        {
            user.StreetAddress = streetAddress;
            return this;
        }

        public UserAddressBuilder WithPostCode(string postcode)
        {
            user.Postcode = postcode;
            return this;
        }

        public UserAddressBuilder In(string city)
        {
            user.City = city;
            return this;
        }
    }

    public class FacetedBuilder
    {
        public void Run()
        {
            var ub = new UserBuilder();
            User user = ub
                .Works
                   .At("asdasd")
                   .AsA("qqweqw")
                   .Earning(951224700)
                .Lives
                  .At("qwqwe")
                  .In("qweqwe")
                  .WithPostCode("340000");

            Console.WriteLine(user);

        }
    }
}
