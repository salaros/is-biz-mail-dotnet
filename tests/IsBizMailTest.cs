using System.IO;
using Xunit;
using System.Reflection;
using System;

namespace Salaros.Email.Test
{
    public class IsBizMailTest
    {
        [Fact]
        public void DoValidPassValidation()
        {
            foreach (var businessEmail in EmailSamples.BusinessEmails)
            {
                Assert.True(IsBizMail.IsValid(businessEmail), $"{businessEmail} is not free (business)");
            }

        }

        [Fact]
        public void AreFreeConsideredFree()
        {
            foreach (var freeEmail in EmailSamples.FreeEmails)
            {
                Assert.True(IsBizMail.IsFreeMailAddress(freeEmail), $"{freeEmail} is free");
            }
        }

        [Fact]
        public void DoPatternsWork()
        {
            foreach (var patternEmail in EmailSamples.DomainPatterns)
            {
                Assert.True(IsBizMail.IsFreeMailAddress(patternEmail), $"{patternEmail} is free");
            }
        }

        [Fact]
        public void DoInvalidFail()
        {
            foreach (var invalidEmail in EmailSamples.InvalidEmails)
            {
                Assert.False(IsBizMail.IsValid(invalidEmail), $"{invalidEmail} is invalid");
            }
        }

        [Fact]
        public void AreExceptionsThrown()
        {
            foreach (var invalidEmail in EmailSamples.Throws)
            {
                Assert.Throws<ArgumentException>(() => {
                    IsBizMail.IsFreeMailAddress(invalidEmail as string);
                });
            }
        }

        [Fact]
        public void HasFreeDomainsListPopulated()
        {
            Assert.NotEmpty(IsBizMail.GetFreeDomains());
        }

        [Fact]
        public void HasFreeDomainsPatternsPopulated()
        {
            Assert.NotEmpty(IsBizMail.GetFreeDomainPatterns());
        }

        private static readonly EmailSamples EmailSamples;

        static IsBizMailTest()
        {
            var sampleEmailsPath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            sampleEmailsPath = Path.Combine(sampleEmailsPath, "emailSamples.json");
            var sampleEmailsRaw = File.ReadAllText(sampleEmailsPath);
            EmailSamples = Newtonsoft.Json.JsonConvert.DeserializeObject<EmailSamples>(sampleEmailsRaw);
        }
    }
}
