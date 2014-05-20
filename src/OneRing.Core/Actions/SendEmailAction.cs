using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace OneRing.Core.Actions
{
	public class SendEmailAction : BaseAction
	{
		public IList<string> ToEmails { get; set; }
		public IList<string> CcEmails { get; set; }
		public IList<string> BccEmails { get; set; }
		public string FromEmail { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public bool IsBodyHtml { get; set; }

		public SendEmailAction()
		{
			this.ToEmails = new List<string>();
			this.CcEmails = new List<string>();
			this.BccEmails = new List<string>();
		}

		public override ActionResult Execute()
		{
			ActionResult result = new ActionResult();
			result.WasSuccessful = false;

			try
			{
				SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
				client.EnableSsl = true;
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				client.UseDefaultCredentials = false;
				client.Credentials = new NetworkCredential("ENTER_YOUR_EMAIL", "ENTER_YOUR_PASSWORD");

				MailMessage mail = new MailMessage();
				foreach (var email in this.ToEmails)
				{
					try
					{
						mail.To.Add(new MailAddress(email));
					}
					catch (FormatException fex)
					{
						result.ErrorMessages.Add(fex.Message);
					}
					catch (Exception ex)
					{
						result.ErrorMessages.Add(ex.Message);
					}
				}

				if (mail.To.Count == 0 && this.ToEmails.Count > 0)
					result.WarningMessages.Add("The number of TO emails does not match what was added to the message.");

				foreach (var email in this.CcEmails)
				{
					try
					{
						mail.CC.Add(new MailAddress(email));
					}
					catch (FormatException fex)
					{
						result.ErrorMessages.Add(fex.Message);
					}
					catch (Exception ex)
					{
						result.ErrorMessages.Add(ex.Message);
					}
				}

				if (mail.CC.Count == 0 && this.CcEmails.Count > 0)
					result.WarningMessages.Add("The number of CC emails does not match what was added to the message.");

				foreach (var email in this.BccEmails)
				{
					try
					{
						mail.Bcc.Add(new MailAddress(email));
					}
					catch (FormatException fex)
					{
						result.ErrorMessages.Add(fex.Message);
					}
					catch (Exception ex)
					{
						result.ErrorMessages.Add(ex.Message);
					}
				}

				if (mail.Bcc.Count == 0 && this.BccEmails.Count > 0)
					result.WarningMessages.Add("The number of BCC emails does not match what was added to the message.");

				mail.Subject = this.Subject;
				
				try
				{
					mail.From = new MailAddress(this.FromEmail);
				}
				catch (FormatException fex)
				{
					result.ErrorMessages.Add(fex.Message);
				}
				catch (Exception ex)
				{
					result.ErrorMessages.Add(ex.Message);
				}

				mail.Body = this.Body;
				mail.IsBodyHtml = this.IsBodyHtml;

				client.Send(mail);

				result.WasSuccessful = true;
				result.SuccessMessages.Add("The message was sent successfully!");
			}
			catch (SmtpException sex)
			{
				result.ErrorMessages.Add(sex.Message);
			}
			catch (Exception ex)
			{
				result.ErrorMessages.Add(ex.Message);
			}
			
			return result;
		}
	}
}