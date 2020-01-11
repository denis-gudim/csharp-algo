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

### 2.2. Quick sorting (Hoare partition scheme)

```cs
void Sort<T>(IList<T> collection, IComparer<T> comparer, int low, int high)
{
	if (high <= low) return;

	var p = Partition(collection, comparer, low, high);

	Sort(collection, comparer, low, p);
	Sort(collection, comparer, p + 1, high);
}

int Partition<T>(IList<T> collection, IComparer<T> comparer, int low, int high)
{
	var i = low - 1;
	var j = high + 1;
	var pivot = collection[low];

	while (true)
	{
		while (comparer.Compare(collection[++i], pivot) < 0) { }
		while (comparer.Compare(collection[--j], pivot) > 0) { }

		if (i >= j) return j;

		var tmp = collection[i];
		
		collection[i] = collection[j];
		collection[j] = tmp;
	}
}
```

## Searching

### 1. Linear search

```cs
int Find<T>(IList<T> sequence, T item, IComparer<T> comparer)
{
	var size = sequence.Count;

	for (var i = 0; i < size; i++)
	{
		if (comparer.Compare(item, sequence[i]) == 0)
			return i;
	}

	return -1;
}
```

### 2. Binary search

```cs
int Find<T>(IList<T> sequence, T item, IComparer<T> comparer, int low, int high)
{
	if (low > high)
		return -1;

	var pivot = (low + high) / 2;
	var result = comparer.Compare(item, sequence[pivot]);

	if (result == 0)
		return pivot;

	if (result < 0)
		return Find<T>(sequence, item, comparer, low, pivot - 1);

	return Find<T>(sequence, item, comparer, pivot + 1, high);
}
```