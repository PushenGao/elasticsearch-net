using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Nest
{
	public interface IHasADictionary
	{
		IDictionary Dictionary { get; }
	}
	public interface IHasADictionary<TKey, TValue> : IHasADictionary
	{
		new IDictionary<TKey, TValue> Dictionary { get; }
	}

	public abstract class HasADictionary<TKey, TValue> : IHasADictionary
	{
		protected Dictionary<TKey, TValue> BackingDictionary { get; set; }
		IDictionary IHasADictionary.Dictionary => this.BackingDictionary as IDictionary;

		protected HasADictionary() { this.BackingDictionary = new Dictionary<TKey, TValue>(); }
		protected HasADictionary(Dictionary<TKey, TValue> backingDictionary) { this.BackingDictionary = backingDictionary; }
		protected HasADictionary(IDictionary<TKey, TValue> backingDictionary)
		{
			this.BackingDictionary = new Dictionary<TKey, TValue>(backingDictionary);
		}
	}

	public abstract class HasADictionary<TDescriptor, TKey, TValue> 
		: HasADictionary<TDescriptor, TDescriptor, TKey, TValue>
		where TDescriptor : HasADictionary<TDescriptor, TKey, TValue> { }

	public abstract class HasADictionary<TDescriptor, TInterface, TKey, TValue> 
		: DescriptorBase<TDescriptor, TInterface>, IHasADictionary
		where TDescriptor : HasADictionary<TDescriptor, TInterface, TKey, TValue>, TInterface
		where TInterface : class
	{
		protected Dictionary<TKey, TValue> BackingDictionary { get; set; }
		IDictionary IHasADictionary.Dictionary => this.BackingDictionary;

		protected HasADictionary() { this.BackingDictionary = new Dictionary<TKey, TValue>(); }
		protected HasADictionary(Dictionary<TKey, TValue> backingDictionary) { this.BackingDictionary = backingDictionary; }
		protected HasADictionary(IDictionary<TKey, TValue> backingDictionary)
		{
			this.BackingDictionary = new Dictionary<TKey, TValue>(backingDictionary);
		}
	}
}