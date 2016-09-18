using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace VendingMachine
{
    public class VmCoinBank
    {
        private const int NUM_COINS_TO_RESTOCK = 5;
        private readonly List<string> _coinsInBank;
        private readonly VmCoinValidator _validator;
        private readonly VmCoinSlot _coinSlot;
        private readonly VmCoinReturn _coinReturn;

        public VmCoinBank(List<string> coinsInBank, VmCoinValidator validator, VmCoinSlot coinSlot, VmCoinReturn coinReturn)
        {
            _coinsInBank = coinsInBank;
            _validator = validator;
            _coinSlot = coinSlot;
            _coinReturn = coinReturn;

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

        public void DetermineChange()
        {
            _validator.GetCurrentTransactionTotal();
        }

        public void MakeChange(int changeNeeded)
        {
            bool bOutOfChange = false;
            List<string> changeToGive = new List<string>();
            AcceptMoney(_coinSlot.GetCoinsInCurrentTransaction());

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
            _coinReturn.ReceiveCoin(changeToGive);
        }

        public void AcceptMoney(List<string> coinsToBank)
        {
            coinsToBank.ForEach(_coinsInBank.Add);
            coinsToBank.Clear();
        }

        public bool CanMakeChange()
        {
            return _coinsInBank.Distinct().Count() == 3;
        }
    }
}