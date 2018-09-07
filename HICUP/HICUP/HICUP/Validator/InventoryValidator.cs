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
        private IInventoryRepo _inventoryRepo = new InventoryRepo();
        private List<Inventory> FullInventory = new List<Inventory>();

        public InventoryValidator()
        {
            RuleFor(c => c.Item).Must(n => ValidateStringEmpty(n)).WithMessage("Item name should not be empty.");
            RuleFor(c => c.Item).Must(n => !IsDuplicate(n)).WithMessage("This Item Already Exists!");
            RuleFor(c => c.ItemMeasurement).Must(n => ValidateStringEmpty(n)).WithMessage("Item Measurement should not be empty.");
            RuleFor(c => c.ItemQuantity).NotNull();
        }

        bool ValidateStringEmpty(string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }

        private bool IsDuplicate(string item)
        {

            getInventory();
            return FullInventory.Any(x => x.Item == item.ToUpper());

        }

        void getInventory()
        {
            FullInventory = _inventoryRepo.GetInventory();
        }
    }
}
