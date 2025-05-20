using Finance.Interfaces;
using Finance.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace Finance.Controllers
{
    [ApiController]
    public class FinanceController : Controller
    {
        private readonly FinanceContext _context;
        private readonly IFinance _iFinance;

        public FinanceController(FinanceContext context, IFinance iFinance)
        {
            _context = context;
            _iFinance = iFinance;
        }

        [HttpGet]
        [Route("api/Finance/Index")]
        public IActionResult Index()
        {
            return View();
        }
        #region Get Banking Information
        [HttpGet]
        [Route("api/Finance/GetCustomerById/{id:guid}")]
        public ActionResult getCustomerById(Guid id)
        {
            var _customer = _context.Customers.Where(c => c.CustomerId == id).SingleOrDefault();
            string customer = JsonConvert.SerializeObject(_customer);
            return Ok(customer);
        }

        [HttpGet]
        [Route("api/Finance/GetCustomerAccountById/{id:guid}")]
        public ActionResult getCustomerAccountById(Guid id)
        {
            var _account = _context.Accounts.Where(c => c.AccountId == id).FirstOrDefault();
            string account = JsonConvert.SerializeObject(_account);
            return Ok(account);
        }

        [HttpGet]
        [Route("api/Finance/GetCustomerAccountBalanceById/{id:guid}")]
        public ActionResult getCustomerAccountBalanceById(Guid id)
        {
            var _accountBalance = _context.AccountBalances.Where(c => c.AccountId == id).FirstOrDefault();
            string accountBalance = JsonConvert.SerializeObject(_accountBalance);
            return Ok(accountBalance);
        }

        [HttpGet]
        [Route("api/Finance/GetCustomerBankById/{id}")]
        public ActionResult getCustomerBankById(int bankId)
        {
            var _bank = _context.Banks.Where(c => c.Id == bankId).FirstOrDefault();
            string bank = JsonConvert.SerializeObject(_bank);
            return Ok(bank);
        }

        [HttpGet]
        [Route("api/Finance/GetCustomerBankCardById/{id:guid}")]
        public ActionResult getCustomerBankCardById(Guid id)
        {
            var _bankCard = _context.BankCards.Where(c => c.AccountId == id).FirstOrDefault();
            string bankCard = JsonConvert.SerializeObject(_bankCard);
            return Ok(bankCard);
        }

        [HttpGet]
        [Route("api/Finance/GetCustomerBankTransactionById/{id:guid}")]
        public ActionResult getCustomerBankTransactionById(Guid id)
        {
            var _transactions = _context.Transactions.Where(c => c.AccountId == id).FirstOrDefault();
            string transactions = JsonConvert.SerializeObject(_transactions);
            return Ok(transactions);
        }

        [HttpGet]
        [Route("api/Finance/GetCustomerBankTransactionMessagesById/{id}")]
        public ActionResult getCustomerBankTransactionMessagesById(int customerId)
        {
            var _tranMessages = _context.TransactionMessages.Where(c => c.Id == customerId).FirstOrDefault();
            string tranMessages = JsonConvert.SerializeObject(_tranMessages);
            return Ok(_tranMessages);
        }

        [HttpGet]
        [Route("api/Finance/GetCustomerPartyById/{id}")]
        public ActionResult getCustomerPartyById(int customerId)
        {
            var _custParty = _context.Parties.Where(c => c.Id == customerId).FirstOrDefault();
            string custParty = JsonConvert.SerializeObject(_custParty);
            return Ok(custParty);
        }

        [HttpGet]
        [Route("api/Finance/GetCustomerBankTransactionTypeById/{id}")]
        public ActionResult getCustomerBankTransactionTypeById(string transactionType)
        {
            var _tranType = _context.TransactionTypes.Where(c => c.Transactiontype1 == transactionType).FirstOrDefault();
            string tranType = JsonConvert.SerializeObject(_tranType);
            return Ok(tranType);
        }
        #endregion

        #region Edit Banking Information
        [HttpPut]
        [Route("api/Finance/EditCustomerById/{id:guid}")]
        public ActionResult EditCustomerById([FromBody] JsonElement customer, Guid id)
        {
            if (!String.IsNullOrEmpty(customer.ToString()))
            {
                var _cust = _context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
                var custDS = JsonConvert.DeserializeObject<Customer>(customer.ToString());
                if (_cust != null)
                {
                    _cust.Firstname = custDS.Firstname;
                    _cust.Middlename = custDS.Middlename;
                    _cust.Lastname = custDS.Lastname;
                    _cust.Suffix = custDS.Suffix;
                    _cust.Email = custDS.Email;
                    _cust.Customertype = custDS.Customertype;
                    _cust.CustomertypeId = custDS.CustomertypeId;
                    _cust.DateBecameCustomer = custDS.DateBecameCustomer;
                    _cust.Phone = custDS.Phone;
                    _context.Update(_cust);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/Finance/EditCustomerAccountById/{id:guid}")]
        public ActionResult EditCustomerAccountById([FromBody] JsonElement account, Guid id)
        {
            if (!String.IsNullOrEmpty(account.ToString()))
            {
                var _acct = _context.Accounts.Where(a => a.AccountId == id).FirstOrDefault();
                var acctDS = JsonConvert.DeserializeObject<Account>(account.ToString());
                if (_acct != null)
                {
                    _acct.CustomerName = acctDS.CustomerName;
                    _acct.Status = acctDS.Status;
                    _acct.LastActivity = acctDS.LastActivity;
                    _context.Update(_acct);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/Finance/EditCustomerAccountBalanceById/{id:guid}")]
        public ActionResult EditCustomerAccountBalanceById([FromBody] JsonElement balance, Guid id)
        {
            if (!String.IsNullOrEmpty(balance.ToString()))
            {
                var _bal = _context.AccountBalances.Where(b => b.AccountId == id).FirstOrDefault();
                var balDS = JsonConvert.DeserializeObject<AccountBalance>(balance.ToString());
                if (_bal != null)
                {
                    _bal.CurrentBalance = balDS.CurrentBalance;
                    _bal.NewBalance = balDS.NewBalance;
                    _bal.PreviousBalance = balDS.PreviousBalance;
                    _bal.TransactionDate = balDS.TransactionDate;
                    _context.Update(_bal);
                    _context.SaveChanges();
                }
            }
            else { return NotFound(); }
            return Ok();
        }

        [HttpPut]
        [Route("api/Finance/EditCustomerBankById/{id}")]
        public ActionResult EditCustomerBankById([FromBody] JsonElement bank, int bankId)
        {
            if (!String.IsNullOrEmpty(bank.ToString()))
            {
                var _bank = _context.Banks.Where(b => b.Id == bankId).FirstOrDefault();
                var bankDS = JsonConvert.DeserializeObject<Bank>(bank.ToString());
                if (_bank != null)
                {
                    _bank.Name = bankDS.Name;
                    _bank.Location = bankDS.Location;
                    _bank.Accountcurrency = bankDS.Accountcurrency;
                    _bank.Accountbal = bankDS.Accountbal;
                    _bank.Deposit = bankDS.Deposit;
                    _bank.Withdrawal = bankDS.Withdrawal;
                    _context.Update(_bank);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        [Route("api/Finance/EditCustomerBankCardById/{id:guid}")]
        public ActionResult EditCustomerBankCardById([FromBody] JsonElement bankCard, Guid id)
        {
            if (string.IsNullOrEmpty(bankCard.ToString()))
            {
                var _bankCard = _context.BankCards.Where(c => c.AccountId == id).FirstOrDefault();
                var bankCardDS = JsonConvert.DeserializeObject<BankCard>(bankCard.ToString());
                if (_bankCard != null)
                {
                    _bankCard.Cardnumber = bankCardDS.Cardnumber;
                    _bankCard.Cardtype = bankCardDS.Cardtype;
                    _bankCard.Csv = bankCardDS.Csv;
                    _bankCard.Issuedate = bankCardDS.Issuedate;
                    _bankCard.Expirationmonth = bankCardDS.Expirationmonth;
                    _bankCard.Expirationyear = bankCardDS.Expirationyear;
                    _bankCard.Expirationdate = bankCardDS.Expirationdate;
                    _context.Update(_bankCard);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        [HttpPut]
        [Route("api/Finance/EditCustomerBankTransactionById/{id:guid}")]
        public ActionResult EditCustomerBankTransactionById([FromBody] JsonElement bankTran, Guid id)
        {
            if (!String.IsNullOrEmpty(bankTran.ToString()))
            {
                var _bankTran = _context.Transactions.Where(t => t.AccountId == id).FirstOrDefault();
                var bankTranDS = JsonConvert.DeserializeObject<Transaction>(bankTran.ToString());
                if (_bankTran != null)
                {
                    _bankTran.Account = bankTranDS.Account;
                    _bankTran.TransactionDate = bankTranDS.TransactionDate;
                    _bankTran.Type = bankTranDS.Type;
                    _context.Update(_bankTran);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        [Route("api/Finance/EditCustomerBankTransactionMessagesById/{id}")]
        public ActionResult EditCustomerBankTransactionMessagesById([FromBody] JsonElement bankTranMsg, int customerId)
        {
            if (!String.IsNullOrEmpty(bankTranMsg.ToString()))
            {
                var _tranMsg = _context.TransactionMessages.Where(m => m.Id == customerId).FirstOrDefault();
                var tranMsgDS = JsonConvert.DeserializeObject<TransactionMessage>(bankTranMsg.ToString());
                if (_tranMsg != null)
                {
                    _tranMsg.Message = tranMsgDS.Message;
                    _tranMsg.TransactionTypeCode = tranMsgDS.TransactionTypeCode;
                    _tranMsg.Counterparty = tranMsgDS.Counterparty;
                    _context.Update(_tranMsg);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        [Route("api/Finance/EditCustomerPartyById/{id}")]
        public ActionResult EditCustomerPartyById([FromBody] JsonElement party, int customerId)
        {
            if (!String.IsNullOrEmpty(party.ToString()))
            {
                var _party = _context.Parties.Where(p => p.Id == customerId).FirstOrDefault();
                var partyDS = JsonConvert.DeserializeObject<Party>(party.ToString());
                if (_party != null)
                {
                    _party.Name = partyDS.Name;
                    _party.Email = partyDS.Email;
                    _party.Details = partyDS.Details;
                    _party.Phone = partyDS.Phone;
                    _context.Update(_party);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        [Route("api/Finance/EditTransactionTypeByCode/{code}")]
        public ActionResult EditTransactionTypeByCode([FromBody] JsonElement ttc, string code)
        {
            if (!String.IsNullOrEmpty(ttc.ToString()))
            {
                var _ttc = _context.TransactionTypes.Where(t => t.TransactionTypeCode == code).FirstOrDefault();
                var ttcDS = JsonConvert.DeserializeObject<TransactionType>(_ttc.ToString());
                if (_ttc != null)
                {
                    _ttc.Transactiontype1 = ttcDS.Transactiontype1;
                    _ttc.TransactionTypeCode = ttcDS.TransactionTypeCode;
                    _ttc.Description = ttcDS.Description;
                    _context.Update(_ttc);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        #endregion

        #region Create Financial Information
        [HttpPost]
        [Route("api/Finance/CreateCustomer")]
        public ActionResult CreateCustomer([FromBody] JsonElement customer)
        {
            if (!String.IsNullOrEmpty(customer.ToString()))
            {
                var custDS = JsonConvert.DeserializeObject<Customer>(customer.ToString());
                Customer _cust = (Customer)custDS;
                _context.Add(_cust);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Finance/CreateCustomerAccount")]
        public ActionResult CreateCustomerAccount([FromBody] JsonElement account)
        {
            if (!String.IsNullOrEmpty(account.ToString()))
            {
                var acct = JsonConvert.DeserializeObject<Account>(account.ToString());
                Account _acct = (Account)acct;
                _context.Add(_acct);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Finance/CreateCustomerAccountBalance")]
        public ActionResult CreateCustomerAccountBalance([FromBody] JsonElement balance)
        {
            if (!String.IsNullOrEmpty(balance.ToString()))
            {
                var bal = JsonConvert.DeserializeObject<AccountBalance>(balance.ToString());
                AccountBalance _bal = (AccountBalance)bal;
                _context.Add(_bal);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Finance/CreateCustomerBank")]
        public ActionResult CreateCustomerBank([FromBody] JsonElement bank)
        {
            if (!String.IsNullOrEmpty(bank.ToString()))
            {
                var bnk = JsonConvert.DeserializeObject<Bank>(bank.ToString());
                Bank _bank = (Bank)bnk;
                _context.Add(_bank);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Finance/CreateCustomerBankCard")]
        public ActionResult CreateCustomerBankCardById([FromBody] JsonElement bankCard)
        {
            if (!String.IsNullOrEmpty(bankCard.ToString()))
            {
                var card = JsonConvert.DeserializeObject<BankCard>(bankCard.ToString());
                BankCard _bankCard = (BankCard)card;
                _context.Add(_bankCard);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Finance/CreateCustomerBankTransaction")]
        public ActionResult CreateCustomerBankTransactionById([FromBody] JsonElement bankTran)
        {
            if (!String.IsNullOrEmpty(bankTran.ToString()))
            {
                var tran = JsonConvert.DeserializeObject<Transaction>(bankTran.ToString());
                Transaction _transaction = (Transaction)tran;
                _context.Add(_transaction);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Finance/CreateCustomerBankTransactionMessages")]
        public ActionResult CreateCustomerBankTransactionMessagesById([FromBody] JsonElement tranMsg)
        {
            if (!String.IsNullOrEmpty(tranMsg.ToString()))
            {
                var msg = JsonConvert.DeserializeObject<TransactionMessage>(tranMsg.ToString());
                TransactionMessage _msg = (TransactionMessage)msg;
                _context.Add(_msg);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Finance/CreateCustomerParty")]
        public ActionResult CreateCustomerPartyById([FromBody] JsonElement custParty)
        {
            if (!String.IsNullOrEmpty(custParty.ToString()))
            {
                var party = JsonConvert.DeserializeObject<Party>(custParty.ToString());
                Party _party = (Party)party;
                _context.Add(_party);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Finance/CreateCustomerTransactionType")]
        public ActionResult CreateCustomerBankTransactionTypeById([FromBody] JsonElement tranType)
        {
            if (!String.IsNullOrEmpty(tranType.ToString()))
            {
                var type = JsonConvert.DeserializeObject<TransactionType>(tranType.ToString());
                TransactionType _tranType = (TransactionType)type;
                _context.Add(_tranType);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
        #endregion
    }
}
