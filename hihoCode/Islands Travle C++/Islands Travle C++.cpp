// Islands Travle C++.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <math.h>
#include <stdlib.h>

int caculate(int *X, int *Y, int i, int j)
{
	int x = abs(X[i] - X[j]);
	int y = abs(Y[i] - Y[j]);

	return x < y ? x : y;
}

int _tmain(int argc, _TCHAR* argv[])
{
	int size = 0;
	scanf("%d", &size);
	int *X = (int *)malloc(size * sizeof(int));
	int *Y = (int *)malloc(size * sizeof(int));

	for (int i = 0; i < size; i++)
	{
		scanf("%d %d", &X[i], &Y[i]);
	}

	int i = 0, j = 0;
	int *visited = (int *)malloc(size * sizeof(int));
	for (i = 0; i < size; i++)
	{
		visited[i] = 0;
	}
	int *distance = (int *)malloc(size * sizeof(int));
	int min = 0, last = 0;
	for (int j = 1; j < size; j++)
	{
		distance[j] = caculate(X, Y, 0, j);
		min = distance[min] < distance[j] ? min : j;
	}
	distance[0] = -1;
	for (int i = 1; i < size; i++)
	{
		visited[min] = 1;
		last = min;
		min = 0;
		for (int j = 1; j < size; j++)
		{
			if (!visited[j])
			{
				int tmp = distance[last] + caculate(X, Y, last, j);
				distance[j] = distance[j] < tmp ? distance[j] : tmp;
				if (distance[min] > 0)
				{
					min = distance[min] < distance[j] ? min : j;
				}
				else 
				{
					min = j;
				}
			}
		}
		if (min == size - 1)
		{
			printf("%d", distance[min]);
		}
	}

	return 0;
}

