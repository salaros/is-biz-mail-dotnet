using System.IO;
using Xunit;
using System.Reflection;
using System;
using System.Linq;

namespace Salaros.Email.Tests
{
    public class IsBizMailTest
    {
        [Fact]
        public void DoValidPassValidation()
        {
            Assert.NotNull(EmailSamples.Business);
            Assert.NotEmpty(EmailSamples.Business);

            foreach (var businessEmail in EmailSamples.Business)
            {
                Assert.True(IsBizMail.IsValid(businessEmail), $"{businessEmail} is not free (business)");
            }

        }

        [Fact]
        public void AreFreeConsideredFree()
        {
            Assert.NotNull(EmailSamples.Free);
            Assert.NotEmpty(EmailSamples.Free);

            foreach (var freeEmail in EmailSamples.Free)
            {
                Assert.True(IsBizMail.IsFreeMailAddress(freeEmail), $"{freeEmail} is free");
            }
        }

        [Fact]
        public void DoPatternsWork()
        {
            Assert.NotNull(EmailSamples.DomainPatterns);
            Assert.NotEmpty(EmailSamples.DomainPatterns);

            foreach (var patternEmail in EmailSamples.DomainPatterns)
            {
                Assert.True(IsBizMail.IsFreeMailAddress(patternEmail), $"{patternEmail} is free");
            }
        }

        [Fact]
        public void DoInvalidFail()
        {
            Assert.NotNull(EmailSamples.Invalid);
            Assert.NotEmpty(EmailSamples.Invalid);

            foreach (var invalidEmail in EmailSamples.Invalid.Concat(EmailSamples.Incomplete))
            {
                Assert.False(IsBizMail.IsValid(invalidEmail), $"{invalidEmail} is invalid");
            }
        }

        [Fact]
        public void AreExceptionsThrown()
        {
            Assert.NotNull(EmailSamples.Throws);
            Assert.NotEmpty(EmailSamples.Throws);

            foreach (var errorTrigger in EmailSamples.Throws.Select(t => t as string).Concat(EmailSamples.Incomplete))
            {
                Assert.Throws<ArgumentException>(() => {
                    IsBizMail.IsFreeMailAddress(errorTrigger);
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
            sampleEmailsPath = Path.Combine(sampleEmailsPath, "email-test-samples.json");
            var sampleEmailsRaw = File.ReadAllText(sampleEmailsPath);
            EmailSamples = Newtonsoft.Json.JsonConvert.DeserializeObject<EmailSamples>(sampleEmailsRaw);
        }
    }
}
