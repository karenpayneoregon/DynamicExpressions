Imports System.Linq.Expressions
Imports System.Runtime.CompilerServices

Public Module GenericSorterExtension
    Public Enum SortDirection
        ''' <summary>
        ''' Sort ascending.
        ''' </summary>
        Ascending
        ''' <summary>
        ''' Sort descending.
        ''' </summary>
        Descending
    End Enum
    <Extension>
    Public Function Sort(Of T)(list As List(Of T), propertyName As String, sortDirection As SortDirection) As List(Of T)
        'Dim sortProperties() As String = sortDirection.Split(" "c)
        Dim param = Expression.Parameter(GetType(T), "item")

        Dim sortExpression = Expression.Lambda(Of Func(Of T, Object))(
            Expression.Convert(Expression.Property(param, propertyName), GetType(Object)), param)

        Select Case sortDirection
            Case SortDirection.Ascending
                list = list.AsQueryable().OrderBy(sortExpression).ToList()
            Case Else
                list = list.AsQueryable().OrderByDescending(sortExpression).ToList()
        End Select

        Return list

    End Function
    Public Enum SortOrderEnum
        ''' <summary>
        ''' The returned list will be ordered in acending order
        ''' </summary>
        ASC
        ''' <summary>
        ''' The returned list wil lbe orderded in descending order
        ''' </summary>
        DESC
    End Enum
    <System.Runtime.CompilerServices.Extension>
    Public Function Order(Of T)(source As IQueryable(Of T), ByVal propertyNames() As String, sortOrder As SortOrderEnum) As IOrderedQueryable(Of T)

        If propertyNames.Length = 0 Then
            Throw New InvalidOperationException()
        End If

        Dim param = Expression.Parameter(GetType(T), String.Empty)
        Dim [property] = Expression.PropertyOrField(param, propertyNames(0))

        Dim sort = Expression.Lambda([property], param)

        Dim orderByCall As MethodCallExpression = Expression.Call(GetType(Queryable), "OrderBy" &
            (If(sortOrder = SortOrderEnum.DESC, "Descending",
                String.Empty)),
                    {GetType(T), [property].Type},
                        source.Expression,
                                        Expression.Quote(sort))

        If propertyNames.Length > 1 Then
            For index As Integer = 1 To propertyNames.Length - 1
                Dim item = propertyNames(index)
                param = Expression.Parameter(GetType(T), String.Empty)
                [property] = Expression.PropertyOrField(param, item)

                sort = Expression.Lambda([property], param)

                orderByCall = Expression.Call(GetType(Queryable), "ThenBy" &
                    (If(sortOrder = SortOrderEnum.DESC, "Descending",
                        String.Empty)),
                            {GetType(T), [property].Type},
                                orderByCall,
                                              Expression.Quote(sort))

            Next index
        End If


        Return CType(source.Provider.CreateQuery(Of T)(orderByCall), IOrderedQueryable(Of T))

    End Function
End Module
