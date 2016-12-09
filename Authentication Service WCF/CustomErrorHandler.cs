using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using InternshipAuthenticationService.Models.Exceptions;
using InternshipAuthenticationService.Models.Faults;
using log4net;
using log4net.Config;

namespace InternshipAuthenticationService.AuthenticationService
{

    public class CustomErrorHandler : IErrorHandler
    {
        private readonly ILog _log;
        public CustomErrorHandler(ILog log)
        {

            _log = log;
        }

        public bool HandleError(Exception error)
        {
            _log.Error(error.Message);
            return false;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is InvalidRoleException)
            {
                FaultException<InvalidRoleFault> faultException =
                                            new FaultException<InvalidRoleFault>(
                                            new InvalidRoleFault(error.Message),
                                            error.Message);
                MessageFault messageFault = faultException.CreateMessageFault();
                fault = Message.CreateMessage(version, messageFault, faultException.Action);
            }
            else
            {
                FaultException<string> faultException =
                                            new FaultException<string>(error.Message);
                MessageFault messageFault = faultException.CreateMessageFault();
                fault = Message.CreateMessage(version, messageFault, faultException.Action);
            }
        }
    }
}