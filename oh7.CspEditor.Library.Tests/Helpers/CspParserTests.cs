using NUnit.Framework;
using oh7.CspEditor.Library.Helpers;

namespace oh7.CspEditor.Library.Tests.Helpers
{
    [TestFixture()]
    public class CspParserTests
    {
        [Test()]
        public void ParseCspTest()
        {
            var parser = new CspParser();
            const int projectId = 1;
            const string csp = "default-src 'self'; script-src 'self' https://tagmanager.google.com https://www.google-analytics.com https://az416426.vo.msecnd.net https://static.hotjar.com https://vars.hotjar.com https://script.hotjar.com https://connect.facebook.net https://js.hs-scripts.com https://js.hs-analytics.net https://js.hs-banner.com https://snap.licdn.com https://www.googletagmanager.com/ 'unsafe-eval' 'sha256-q9dd8IIjXxIeD7CT8ATU1eQHzAtLMKiOONg9pq0zhw0=' 'sha256-DQDLKRiUdq7jccHM5VNecRP8tBQ6yATCKUZCcwB2u50=' 'sha256-e+pJn6IuZPKMxMogiKCEWhkiyxjIIOnYMxHQFl/Wra8=' 'sha256-NEvxIweFUeEZCfUob+9E5OSgKA9+R2qNAjftKG9FpTI=' 'sha256-Bn23t6A6ahfx1X9QQ7Zq5CEsVhfElBZMM7zPG3LJ0nE=' 'sha256-NEcRuQuYiuVsBtwY4jok13/HAosPHO6hsRQmUOE/twI=' 'sha256-6+f6r0y7eNLUA1hHKpoVQyCcTkd/U6QejP1K8AtxEGI=' 'sha256-CHqADWZ8juWnop+/oXcA5EqUTGzUMJl2Wcqq29iFgQQ=' 'sha256-qXOPaAzrChWfGkkFmADJoVGTM2ACEy96WXP1LElRXwM=' 'sha256-+3muoJG2BUASBPN4odqE/KotgPw0bJDjMowXTnuHA9s=' 'sha256-FP9z42blppLwwhXCG0UPZLKSAKleq9NXsY13CLfeg4c=' 'sha256-PpbZZvWLkE8o0a5c9lhdb2WTdbTKwpzOgdjADqzQT44=' 'sha256-8qV/K9t6GNQYXkcKUyoc891uppI4E3Czwsz1l+1QSSI=' 'sha256-47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=' 'sha256-eeNbM8rFscsle3hsLWliE5E+85CIbdHgNv674/LvsdU=' 'sha256-8DD2Fyoc4ufgXsEvr1+S4PrEdTSM+M34CqEFrPCETHE=' 'sha256-DFhaeoxBPBVZZul+j4xZnA4CVWF8QQZSCgNTC9eZJ6Y=' 'sha256-kNgEEnatoJ54FItcM5a0PFbBUFWj42fJH6bls5/iUW0=' 'sha256-E6gst5wo0dis3qpC7+6W7zU+gZZkGQSpO1ZEu5wfrs8=' 'sha256-PSHf9SK/pL+J+CmM9+tZh4lLjgpR5oiT0tMPpN3iNGM=' 'sha256-M5C9mpf1122zOSWlkSEuwkh3DTT75bxZgsQmfWeKsR0='; style-src 'self' 'sha256-9rktBnziGpkZM0Cro2If5asPbbknsBrcDgH0MaZLMm8=' 'sha256-ZdHxw9eWtnxUb3mk6tBS+gIiVUPE3pGM470keHPDFlE=' 'sha256-qI/I6/EkaaTpb4+JF4X44r0sf2v7p243GOqj1wVsI8c=' https://tagmanager.google.com https://fonts.googleapis.com 'sha256-ICa0DhwZQJsOd/Rn0N8H6FdQ71GfNL+op2zhAQ+Y4mM=' 'sha256-SvLgADqEePEV9RNxBrRQXSBJafFHcVNG7cPzHz6h9eA=' 'sha256-9rktBnziGpkZM0Cro2If5asPbbknsBrcDgH0MaZLMm8=' 'sha256-ZdHxw9eWtnxUb3mk6tBS+gIiVUPE3pGM470keHPDFlE=' 'sha256-qI/I6/EkaaTpb4+JF4X44r0sf2v7p243GOqj1wVsI8c=' 'sha256-hpQQz17bu4r88dFh3cV9MvY6HE9XqDFcpoCJqFykq0M=' 'sha256-47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=' 'sha256-J84pSWscYsy36e5EuZEb3D2wODkj8LitwYEh8asqfRs=' 'sha256-7QhgtmTR3jP1ubU8+jAyulzq1vLk1QVZSZ/gkk2vgh4=' 'sha256-8qM8YQGFG19AunmFi1sKdMTZUoI/FoQ9xJB6YIv2X8Y=' 'sha256-F7yDrbXcmYCNecQfe06pBgktoPntwCvi9+8EpkZLrAQ=' 'sha256-7AMgn9mEMIgcpyJKGC4SoEtNW4Q7o+Z7dppe5jM0xG0=' 'sha256-nuTXJYpDaIsCDYaJD1nnOsTO212H44OoxvcEoQ7cwxQ=' 'sha256-93Ya6eD+iwkxsQgWttHis9ZTs6HTFX0oypjb3DZnoV8='; img-src 'self' https://ssl.gstatic.com https://www.gstatic.com https://www.facebook.com https://px.ads.linkedin.com https://track.hubspot.com https://www.google.com https://www.google.no https://www.googletagmanager.com; font-src 'self' https://fonts.gstatic.com data:; connect-src 'self' https://preprod.sgfinans24.no https://preprod.sgfinans24.se https://preprod.sgfinans24.dk https://www.google-analytics.com https://stats.g.doubleclick.net https://in.hotjar.com https://dc.services.visualstudio.com; object-src 'none'; frame-src 'self' https://vars.hotjar.com https://www.youtube.com/;";

            var parseResult = parser.ParseCsp(projectId, csp);

            Assert.IsTrue(parseResult, "Failed to parse CSP");
        }
    }
}