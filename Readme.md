# C# based algorithms examples

Just another one repository with simple algorithms implementation based on C# programming language

## Sorting

### 1. Bubble sorting

```cs
void Sort<T>(IList<T> collection, IComparer<T> comparer)
{
	var size = collection.Count;

	for (var i = 0; i < size; i++)
	{
		for (var j = 1; j < size; j++)
		{
			var left = collection[j - 1];
			var right = collection[j];

			if (comparer.Compare(left, right) <= 0) 
			continue;

			collection[j - 1] = right;
			collection[j] = left;
		}
	}
}
```

### 2.1. Quick sorting (Lomuto partition scheme)

```cs
void Sort<T>(IList<T> collection, IComparer<T> comparer, int low, int high)
{
	if(high < low) return;

	var p = Partition(collection, comparer, low, high);

	Sort(collection, comparer, low, p - 1);
	Sort(collection, comparer, p + 1, high);
}

int Partition<T>(IList<T> collection, IComparer<T> comparer, int low, int high)
{
	var i = low;
	var pivot = collection[high];

	for (var j = low; j < high; j++)
	{
		var item = collection[j];

		if (comparer.Compare(item, pivot) > 0) continue;

		collection[j] = collection[i];
		collection[i] = item;

		i++;
	}

	collection[high] = collection[i];
	collection[i] = pivot;

	return i;
}
```
