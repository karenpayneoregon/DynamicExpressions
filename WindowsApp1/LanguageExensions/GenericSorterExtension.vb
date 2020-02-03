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
        ''' The returned list will be ordered in ascending order
        ''' </summary>
        ASC
        ''' <summary>
        ''' The returned list will be order in descending order
        ''' </summary>
        DESC
    End Enum
    <Extension>
    Public Function Order(Of T)(source As IQueryable(Of T), ByVal propertyNames() As String, sortOrder As SortOrderEnum) As IOrderedQueryable(Of T)

        If propertyNames.Length = 0 Then
            Throw New InvalidOperationException()
        End If

        Dim paramExpression = Expression.Parameter(GetType(T), String.Empty)
        Dim memberExpression = Expression.PropertyOrField(paramExpression, propertyNames(0))

        Dim sort = Expression.Lambda(memberExpression, paramExpression)

        Dim orderByCall As MethodCallExpression = Expression.Call(GetType(Queryable), "OrderBy" &
            (If(sortOrder = SortOrderEnum.DESC, "Descending", String.Empty)), {GetType(T), memberExpression.Type},
                source.Expression, Expression.Quote(sort))

        If propertyNames.Length > 1 Then

            For index As Integer = 1 To propertyNames.Length - 1
                Dim item = propertyNames(index)
                paramExpression = Expression.Parameter(GetType(T), String.Empty)
                memberExpression = Expression.PropertyOrField(paramExpression, item)

                sort = Expression.Lambda(memberExpression, paramExpression)

                orderByCall = Expression.Call(GetType(Queryable), "ThenBy" &
                    (If(sortOrder = SortOrderEnum.DESC, "Descending", String.Empty)),
                        {GetType(T), memberExpression.Type}, orderByCall, Expression.Quote(sort))

            Next
        End If


        Return CType(source.Provider.CreateQuery(Of T)(orderByCall), IOrderedQueryable(Of T))

    End Function
End Module
