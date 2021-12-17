using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartApp.Services
{
    public class ApiServices
    {

        /// <summary>Registers the asynchronous. Converting Http object to Json.</summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirmPassword">The confirm password.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://localhost:44312/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }


        /// <summary>Logins the asynchronous. Creating key value pair for 
        /// username, password and grant_type(authentication).</summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<string> LoginAsync(string userName, string password)
        {

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44312/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var jwt = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);

            var accessToken = jwtDynamic.Value<string>("access_token");

            Debug.WriteLine(jwt);
            return accessToken;
        }


        /// <summary>Gets the ideas asynchronous.</summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<List<Idea>> GetIdeasAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);

            var json = await client.GetStringAsync("https://localhost:44312/api/ideas");

            var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);

            return ideas;
        }



        /// <summary>Posts the idea asynchronous.
        /// Create new http client, access the token suing Authorization</summary>
        /// <param name="idea">The idea.</param>
        /// <param name="accessToken">The access token.</param>
        public async Task PostIdeaAsync(Idea idea, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);

            var json = JsonConvert.SerializeObject(idea);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var pulse = await client.PostAsync("https://localhost:44312/api/ideas", content);

            if (pulse.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "Hooray 🎈🎉 You've successfully made a new post 👍🏿 !", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "Check your internet connection and try again 😥 !", "OK");
            }

        }


        /// <summary>Puts the idea asynchronous.</summary>
        /// <param name="idea">The idea.</param>
        /// <param name="accessToken">The access token.</param>
        public async Task PutIdeaAsync(Idea idea, string accessToken)
        {
            var claim = new HttpClient();
            claim.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);

            var json = JsonConvert.SerializeObject(idea);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await claim.PutAsync("https://localhost:44312/api/ideas/" + idea.Id, content);

            if (response.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "Hooray 🎈🎉 You've successfully edited your post 👍🏿 !", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Notification !", "An error occured while trying to edit a post " +
                            "Please make sure you're the creator of the post and try again 😥 !", "OK");
            }


        }
    }
}
