using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using static dnsimple.Services.JsonTools<dnsimple.Services.Account>;

namespace dnsimple.Services
{
    /// <summary>
    /// Lists the accounts the authenticated entity has access to.
    /// </summary>
    /// <see>http://developer.dnsimple.com/v2/accounts</see>
    /// <example>
    /// <code>
    ///     var accounts = client.Accounts.List();
    /// </code>
    /// </example>
    /// <see>https://developer.dnsimple.com/v2/accounts/</see>
    public class AccountsService : Service
    {
        /// <inheritdoc cref="Service"/>
        public AccountsService(IClient client) : base(client) {}

        /// <summary>
        /// Returns a <c>AccountsResponse</c> containing a list of the accounts
        /// the authenticated entity has access to.
        /// </summary>
        /// <returns>An <c>AccountsResponse</c> object</returns>
        public ListDnsimpleResponse<Account> List()
        {
            return new ListDnsimpleResponse<Account>(
                Client.Http.Execute(Client.Http.RequestBuilder("/accounts")
                    .Request));
        }
    }
    
    /// <summary>
    /// Represents the data returned from the API call by transforming the
    /// incoming JSON into a <c>List</c> of <c>Account</c> objects.
    /// </summary>
    /// <see>http://developer.dnsimple.com/v2/accounts</see>
    public readonly struct AccountsData
    {
        /// <summary>
        /// The <c>List</c> of <c>Account</c>s.
        /// </summary>
        public List<Account> Accounts { get; }

        /// <summary>
        /// Creates a new instance of the <c>AccountData</c> object by passing
        /// a <c>JToken</c> representing the JSON returned by the API call.
        /// </summary>
        /// <param name="json"><c>JToken</c> representing the JSON returned</param>
        /// <see cref="JToken"/>
        public AccountsData(JToken json) => 
            Accounts = DeserializeList(json);
    }
}