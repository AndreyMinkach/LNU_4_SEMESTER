#include<iostream>
#include<cstdlib>

using namespace std;

void swap(int *a, int *b)
{
    int temp;
    temp = *a;
    *a = *b;
    *b = temp;
}


int Partition(int a[], int low, int high)
{
    int pivot, index, i;
    index = low;
    pivot = high;

    for(i=low; i < high; i++)
    {
        if(a[i] < a[pivot])
        {
            swap(&a[i], &a[index]);
            index++;
        }
    }
    swap(&a[pivot], &a[index]);

    return index;
}

int RandomPivotPartition(int a[], int low, int high)
{
    for (int i = 0; i <= high; i++)
    {
        std::cout<<a[i]<<" ";
    }
    std::cout<<std::endl;
    int pvt, n;
    n = rand();
    pvt = low + n%(high-low+1);

    swap(&a[high], &a[pvt]);

    return Partition(a, low, high);
}
int randomSelection(int* arr, int start, int end, int position)
{
    for (int i = 0; i <= end; i++)
    {
        std::cout<<arr[i]<<" ";
    }
    std::cout<<std::endl;
  if (start == end)
    return arr[start];

  if (position == 0)
    return -1;

  if (start < end)
  {

    int mid = RandomPivotPartition(arr, start, end);
    int i = mid - start + 1;

    if (i == position)
      return arr[mid];

    else if (position < i)
      return randomSelection(arr, start, mid - 1, position);
    else
      return randomSelection(arr, mid + 1, end, position - i);
  }
}
void quickSort(int arr[], int left, int right)
{

int i = left, j = right;
int tmp;
int pivot = arr[(left + right) / 2];
while (i <= j) {
    while (arr[i] < pivot)
          i++;
    while (arr[j] > pivot)
          j--;
    if (i <= j)
    {
          tmp = arr[i];
          arr[i] = arr[j];
          arr[j] = tmp;
          i++;
          j--;
    }
    for (int i = 0; i <= right; i++)
    {
        std::cout<<arr[i]<<" ";
    }
    std::cout<<std::endl;
};
if (left < j)
    quickSort(arr, left, j);
if (i < right)
    quickSort(arr, i, right);
}

int QuickSortRandom(int a[], int low, int high)
{
    int pindex;
    if(low < high)
    {
        pindex = RandomPivotPartition(a, low, high);
        QuickSortRandom(a, low, pindex-1);
        QuickSortRandom(a, pindex+1, high);
    }
    return 0;
}

int main()
{
    int n, i, t;
    cout<<"Enter the number of data element to be sort: ";
    cin>>n;
    int arr[n];
    for(i = 0; i < n; i++)
    {
        cout<<"Enter element "<<i+1<<": ";
        cin>>arr[i];
    }
    std::cout<<"1 - quick sort, 2 - quick random sort, 3 - random pivot partition"<<std::endl;
    std::cin>>t;
    if(t == 1)
        quickSort(arr, 0, n-1);
    if(t == 2)
    QuickSortRandom(arr, 0, n-1);
    if(t == 3)
    {
        int startPos;
        std::cin>>startPos;
        randomSelection(arr,0, n - 1, startPos);    // Printing
    }
    cout<<"\nSorted Data ";
    for (i = 0; i < n; i++)
        cout<<" -> "<<arr[i];
    std::cout<<std::endl;
    return 0;
}
