﻿namespace Unit.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.ApplicationInsights.Extensibility.Filtering;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Filter tests.
    /// </summary>
    [TestClass]
    public class FilterTests
    {
        #region Input validation
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterThrowsWhenComparandIsNullTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.Equal, Comparand = null };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterThrowsWhenFieldNameIsEmptyTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = string.Empty, Predicate = Predicate.Equal, Comparand = "abc" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterThrowsWhenFieldNameDoesNotExistInTypeTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NonExistentFieldName", Predicate = Predicate.Equal, Comparand = "abc" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }
        #endregion

        #region Generic filtering

        #region Boolean

        [TestMethod]
        public void FilterBooleanEqualTest()
        {
            // ARRANGE
            var equalsTrue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.Equal, Comparand = "true" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { BooleanField = true });
            bool result2 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { BooleanField = false });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterBooleanNotEqualTest()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.NotEqual, Comparand = "true" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(notEqualTrue).Check(new TelemetryMock() { BooleanField = true });
            bool result2 = new Filter<TelemetryMock>(notEqualTrue).Check(new TelemetryMock() { BooleanField = false });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanGreaterThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.GreaterThan, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanLessThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.LessThan, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanGreaterThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanLessThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.LessThanOrEqual, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanContainsTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.Contains, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanDoesNotContainTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.DoesNotContain, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanGarbageComparandTest()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(notEqualTrue);

            // ASSERT
        }

        #endregion

        #region Nullable<Boolean>

        [TestMethod]
        public void FilterNullableBooleanEqualTest()
        {
            // ARRANGE
            var equalsTrue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.Equal, Comparand = "true" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { NullableBooleanField = true });
            bool result2 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { NullableBooleanField = false });
            bool result3 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { NullableBooleanField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterNullableBooleanNotEqualTest()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.NotEqual, Comparand = "true" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(notEqualTrue).Check(new TelemetryMock() { NullableBooleanField = true });
            bool result2 = new Filter<TelemetryMock>(notEqualTrue).Check(new TelemetryMock() { NullableBooleanField = false });
            bool result3 = new Filter<TelemetryMock>(notEqualTrue).Check(new TelemetryMock() { NullableBooleanField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanGreaterThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.GreaterThan, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanLessThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.LessThan, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanGreaterThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanLessThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.LessThanOrEqual, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanContainsTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.Contains, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanDoesNotContainTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.DoesNotContain, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanGarbageComparandTest()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(notEqualTrue);

            // ASSERT
        }

        [TestMethod]
        public void FilterNullableBooleanNullEqualTest()
        {
            // ARRANGE
            var equalsTrue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.Equal, Comparand = "NULL" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { NullableBooleanField = true });
            bool result2 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { NullableBooleanField = false });
            bool result3 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { NullableBooleanField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }
        #endregion

        #region Int

        [TestMethod]
        public void FilterIntEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.Equal, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterIntNotEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.NotEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void FilterIntGreaterThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.GreaterThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterIntLessThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.LessThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterIntGreaterThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterIntLessThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.LessThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterIntContainsTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.Contains, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 152 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 160 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterIntDoesNotContainTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.DoesNotContain, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 152 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 160 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterIntGarbageComparandTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #region Double

        [TestMethod]
        public void FilterDoubleEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.Equal, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 124 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterDoubleNotEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.NotEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 124 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void FilterDoubleGreaterThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.GreaterThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterDoubleLessThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.LessThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterDoubleGreaterThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterDoubleLessThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.LessThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterDoubleContainsTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.Contains, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 157.2 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 160 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterDoubleDoesNotContainTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.DoesNotContain, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 157.2 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 160 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterDoubleGarbageComparandTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #region TimeSpan

        [TestMethod]
        public void FilterTimeSpanEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.Equal, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123") });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("124") });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterTimeSpanNotEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.NotEqual, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123") });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("124") });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void FilterTimeSpanGreaterThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.GreaterThan, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("122.05:00") });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123.05:00") });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123") });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterTimeSpanLessThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.LessThan, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("122.05:00") });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123.05:00") });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123") });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterTimeSpanGreaterThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("122.05:00") });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123.05:00") });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123") });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterTimeSpanLessThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.LessThanOrEqual, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("122.05:00") });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123.05:00") });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123") });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterTimeSpanContainsTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.Contains, Comparand = "2" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterTimeSpanDoesNotContainTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.DoesNotContain, Comparand = "2" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterTimeSpanGarbageComparandTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #region String

        [TestMethod]
        public void FilterStringEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.Equal, Comparand = "abc" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "abc" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "aBc" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "abc1" });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterStringNotEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.NotEqual, Comparand = "abc" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "abc" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "aBc" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "abc1" });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterStringGreaterThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.GreaterThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "122.5" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123.5" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterStringLessThanTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.LessThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "122.5" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123.5" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterStringGreaterThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "122.5" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123.5" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterStringLessThanOrEqualTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.LessThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "122.5" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123.5" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });
            
            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterStringContainsTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.Contains, Comparand = "abc" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "1abc2" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "1aBc2" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterStringDoesNotContainTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.DoesNotContain, Comparand = "abc" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "1abc2" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "1aBc2" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FilterStringGarbageFieldValueTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.LessThan, Comparand = "123.0" };

            // ACT
            new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "Not at all a number" });

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterStringGarbageComparandValueTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.LessThan, Comparand = "Not a number at all" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #endregion

        #region Support for actual telemetry types

        //!!! enumerate real telemetry type's properties through reflection and explicitly state which ones we don't support
        [TestMethod]
        public void FilterSupportsRequestTelemetryTest()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "Name", Predicate = Predicate.Equal, Comparand = "request name" };

            // ACT
            bool result = new Filter<RequestTelemetry>(equalsValue).Check(new RequestTelemetry() { Name = "request name" });

            // ASSERT
            Assert.IsTrue(result);
        }

        #endregion
    }
}