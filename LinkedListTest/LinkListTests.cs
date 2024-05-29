using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LinkedListYieldReturn;

namespace LinkedListYieldReturn.Tests
{
    public class LinkListTests
    {

        
        [Fact]
        // MethodName_Condition_Expectation
        public void Skip_CountLessThanLength_ReturnLinkList()
        {
            // Arrange
            int count = 2;
            var input = new LinkList<int> { 3, 2, 5, 9, 10 };
            var expected = new LinkList<int> { 5, 9, 10 };

            // Act
            var result = input.Skip(count);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Skip_CountGreaterOrEqualToLength_ReturnEmptyLinkList()
        {
            // Arrange
            int count = 8;
            var input = new LinkList<int> { 3, 2, 5, 9, 10 };
            var expected = new LinkList<int> { };

            // Act
            var result = input.Skip(count);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Skip_CountLessOrEqualToZero_ReturnOriginalLinkList()
        {
            int count = -8;
            var input = new LinkList<int> { 3, 2, 5, 9, 10 };
            var expected = new LinkList<int> { 3, 2, 5, 9, 10 };

            var result = input.Skip(count);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Skip_LengthIsZero_ReturnEmptyLinkList()
        {
            int count = 2;
            var input = new LinkList<int> { };
            var expected = new LinkList<int> { };

            var result = input.Skip(count);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Insert_IndexIsLessThanZero_SholdNotDoAnything()
        {
            int insertIndex = -5;
            int insertData = 4;
            var input = new LinkList<int> { 3, 5, 2 };
            var expected = new LinkList<int> { 5, 3, 2 };

            input.Insert(insertIndex, insertData);

            input.Should().BeEquivalentTo(expected);
            input.GetLength().Should().Be(3);
        }

        [Fact]
        public void Insert_IndexIsAtHead_ShouldInsertAtHead()
        {
            int insertIndex = 0;
            int insertData = 4;
            var input = new LinkList<int> { 3, 5, 2 };
            var expected = new LinkList<int> { 4, 5, 3, 2 };

            input.Insert(insertIndex, insertData);

            input.Should().BeEquivalentTo(expected);
            input.GetLength().Should().Be(4);
        }

        [Fact]
        public void Insert_IndexIsAtMiddle_ShouldInsertAtMiddle()
        {
            int insertIndex = 2;
            int insertData = 4;
            var input = new LinkList<int> { 3, 5, 2 };
            var expected = new LinkList<int> { 5, 3, 4, 2 };

            input.Insert(insertIndex, insertData);

            input.Should().BeEquivalentTo(expected);
            input.GetLength().Should().Be(4);
        }

        [Fact]
        public void Insert_IndexIsAtEnd_SholdInsertAtEnd()
        {
            int insertIndex = 3;
            int insertData = 4;
            var input = new LinkList<int> { 3, 5, 2 };
            var expected = new LinkList<int> { 5, 3, 2, 4 };

            input.Insert(insertIndex, insertData);

            input.Should().BeEquivalentTo(expected);
            input.GetLength().Should().Be(4);
        }

        [Fact]
        public void Insert_IndexIsGreaterThanLength_SholdInsertAtEnd()
        {
            int insertIndex = 12;
            int insertData = 4;
            var input = new LinkList<int> { 3, 5, 2 };
            var expected = new LinkList<int> { 5, 3, 2, 4 };

            input.Insert(insertIndex, insertData);

            input.Should().BeEquivalentTo(expected);
            input.GetLength().Should().Be(4);
        }

        [Fact]
        public void Insert_LengthIsZero_SholdInsertAtHead()
        {
            int insertIndex = 0;
            int insertData = 4;
            var input = new LinkList<int> { };
            var expected = new LinkList<int> { 4 };

            input.Insert(insertIndex, insertData);

            input.Should().BeEquivalentTo(expected);
            input.GetLength().Should().Be(1);
        }

        [Fact]
        public void OrderBy_LengthGreaterThanZero_ReturnLinkListInAscendingOrder()
        {
            var input = new LinkList<Student>()
            {
                new Student {StudentId = 9},
                new Student {StudentId = 2},
                new Student {StudentId = 3},
                new Student {StudentId = 14},
                new Student {StudentId = 5},
            };

            var result = input.OrderBy(x => x.StudentId);

            result.Should().BeInAscendingOrder(x => x.StudentId);
            result.GetLength().Should().Be(5);
        }

        [Fact]
        public void OrderBy_LengthIsZero_ReturnEmptyLinkList()
        {
            var input = new LinkedList<Student>();
            var expected = new LinkedList<Student>();

            var result = input.OrderBy(x => x.StudentId);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
