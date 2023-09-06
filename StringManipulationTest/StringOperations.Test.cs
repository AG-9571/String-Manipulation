using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StringManipulation;
using Moq;
using Microsoft.Extensions.Logging;

namespace StringManipulationTest
{
    public class StringOperationsTest
    {        
        [Fact(Skip = "Esta prueva no es valida en este momento,TICKET-001")]
        public void ConcatenateStrings()
        {
            // Arrnge
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.ConcatenateStrings("Hello", "Platzi");

            // Assert            
            Assert.NotNull(result); //  Not null
            Assert.NotEmpty(result); // Not Empty
            Assert.Equal("Hello Platzi", result); // return Hello Platzi  
        }
        [Fact]
        public void IsPalindrome_True()
        {
            // Arrange
            var strOperations = new StringOperations();

            // act
            var result = strOperations.IsPalindrome("ama");

            // Assert
            Assert.True(result); // true
        }
        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperations = new StringOperations();

            // act
            var result = strOperations.IsPalindrome("Hello");

            // Assert
            Assert.False(result); // false
        }
        [Fact]
        public void QuantintyInWords()
        {
            // Arrange
            var strOperations = new StringOperations();
            // act
            var result = strOperations.QuantintyInWords("cat", 6);
            // Assert
            Assert.StartsWith("seis", result); // Start text
            Assert.Contains("cat", result); // Container text or []
        }
        [Fact]
        public void GetStringLength_Exection()
        {
            // Arrange
            var strOperations = new StringOperations();
            // act

            // Assert
            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength( str: null ));
        }
        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber, int expected )
        {
            // Arrange
            var strOperations = new StringOperations();
            // act
            var result = strOperations.FromRomanToNumber(romanNumber);
            // Assert
            Assert.Equal(expected, result);
        }
        // Efecto mock
        [Fact]
        public void CountOccurrences()
        {
            var mocklogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mocklogger.Object);

            var result = strOperations.CountOccurrences("hello platzi", 'l');

            Assert.Equal(3, result);
        }
        [Fact]
        public void ReadFile()
        {
            var strOperations = new StringOperations();
            var mockfileReader = new Mock<IFileReaderConector>();
            mockfileReader.Setup( p => p.ReadString("file.txt")).Returns("Reading file");

            var result = strOperations.ReadFile(mockfileReader.Object, "file.txt");

            Assert.Equal("Reading file", result);
        }

    }
}

