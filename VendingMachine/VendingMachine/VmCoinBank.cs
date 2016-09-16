using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace VendingMachine
{
    public class VmCoinBank
    {
        private const int NUM_COINS_TO_RESTOCK = 5;
        private readonly List<string> _coinsInBank;
        private readonly VmCoinValidator _validator;

        public VmCoinBank(List<string> coinsInBank, VmCoinValidator validator)
        {
            _coinsInBank = coinsInBank;
            _validator = validator;

        }

        public List<string> GetListOfCoinsInBank()
        {
            return _coinsInBank;
        }

        public void Restock()
        {
            for (int i = 0; i < NUM_COINS_TO_RESTOCK; i++)
            {
                _coinsInBank.Add(_validator.GetQuarterDefinition());
                _coinsInBank.Add(_validator.GetDimeDefinition());
                _coinsInBank.Add(_validator.GetNickelDefinition());
            }
        }

        public List<string> GiveChange(int changeNeeded)
        {
            bool bOutOfChange = false;
            List<string> changeToGive = new List<string>();

            while (changeNeeded > 0 && bOutOfChange == false)
            {
                if (changeNeeded - 25 >= 0 && GetListOfCoinsInBank().Contains(_validator.GetQuarterDefinition()))
                {
                    changeToGive.Add("Q");
                    GetListOfCoinsInBank().Remove("Q");
                    changeNeeded -= 25;
                }
                else if (changeNeeded - 10 >= 0 && GetListOfCoinsInBank().Contains(_validator.GetDimeDefinition()))
                {
                    changeToGive.Add("D");
                    GetListOfCoinsInBank().Remove("D");
                    changeNeeded -= 10;
                }
                else if (changeNeeded - 5 >= 0 && GetListOfCoinsInBank().Contains(_validator.GetNickelDefinition()))
                {
                    changeToGive.Add("N");
                    GetListOfCoinsInBank().Remove("N");
                    changeNeeded -= 5;
                }
                else
                {
                    bOutOfChange = true;
                }
            }
            return changeToGive;
        }

        public void AcceptMoney(List<string> coinsToBank)
        {
            coinsToBank.ForEach(_coinsInBank.Add);
        }
    }
}