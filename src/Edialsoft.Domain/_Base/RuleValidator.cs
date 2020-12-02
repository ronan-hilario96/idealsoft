using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edialsoft.Domain._Base
{
    public class RuleValidator
    {
        public readonly List<string> _ErrosMsg;

        private RuleValidator()
        {
            _ErrosMsg = new List<string>();
        }

        public static RuleValidator New()
        {
            return new RuleValidator();
        }

        public RuleValidator When(bool hasError, string msgError)
        {
            if(hasError)
                _ErrosMsg.Add(msgError);

            return this;
        }

        public void TriggerException()
        {
            if (_ErrosMsg.Any())
                throw new DomainException(_ErrosMsg);
        }
    }

    public class DomainException : ArgumentException
    {
        public List<string> MsgErrors { get; set; }

        public DomainException(List<string> msgErrors)
        {
            MsgErrors = msgErrors;
        }
    }
}
