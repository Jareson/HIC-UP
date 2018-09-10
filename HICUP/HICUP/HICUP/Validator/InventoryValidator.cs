using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HICUP.Services;
using HICUP.Models;
using HICUP.ViewModels;
using System.Linq;

namespace HICUP.Validator
{
    public class InventoryValidator : AbstractValidator<Inventory>
    {

        public InventoryValidator()
        {
            RuleFor(c => c.Item).Must(n => ValidateStringEmpty(n)).WithMessage("Item name should not be empty.");
            RuleFor(c => c.ItemMeasurement).Must(n => ValidateStringEmpty(n)).WithMessage("Item Measurement should not be empty.");
            RuleFor(c => c.ItemQuantity).Must(n => ValidateAboveZero(n)).WithMessage("You cannot go below 0 of an item");
            RuleFor(c => c.ItemPrice).Must(n => ValidateAboveZero(n)).WithMessage("Item must have a price.");
            RuleFor(c => c.ItemLocation).Must(n => ValidateStringEmpty(n)).WithMessage("Item Location should not be empty.");
        }

        bool ValidateStringEmpty(string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }

        bool ValidateAboveZero(int intValue)
        {
            if (intValue > 0)
                return true;
            return false;
        }

        bool ValidateAboveZero(decimal intValue)
        {
            if (intValue > 0)
                return true;
            return false;
        }

    }
}
