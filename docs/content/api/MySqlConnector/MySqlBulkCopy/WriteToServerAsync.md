---
title: MySqlBulkCopy.WriteToServerAsync methods
---

# MySqlBulkCopy.WriteToServerAsync method (1 of 3)

Asynchronously copies all rows in the supplied DataTable to the destination table specified by the [`DestinationTableName`](../DestinationTableName/) property of the [`MySqlBulkCopy`](../../MySqlBulkCopyType/) object.

```csharp
public ValueTask WriteToServerAsync(DataTable dataTable, 
    CancellationToken cancellationToken = default(CancellationToken))
```

## See Also

* class [MySqlBulkCopy](../../MySqlBulkCopyType/)
* namespace [MySqlConnector](../../MySqlBulkCopyType/)
* assembly [MySqlConnector](../../../MySqlConnectorAssembly/)

---

# MySqlBulkCopy.WriteToServerAsync method (2 of 3)

Asynchronously copies all rows in the supplied IDataReader to the destination table specified by the [`DestinationTableName`](../DestinationTableName/) property of the [`MySqlBulkCopy`](../../MySqlBulkCopyType/) object.

```csharp
public ValueTask WriteToServerAsync(IDataReader dataReader, 
    CancellationToken cancellationToken = default(CancellationToken))
```

| parameter | description |
| --- | --- |
| dataReader | The IDataReader to copy from. |
| cancellationToken | A token to cancel the asynchronous operation. |

## See Also

* class [MySqlBulkCopy](../../MySqlBulkCopyType/)
* namespace [MySqlConnector](../../MySqlBulkCopyType/)
* assembly [MySqlConnector](../../../MySqlConnectorAssembly/)

---

# MySqlBulkCopy.WriteToServerAsync method (3 of 3)

Asynchronously copies all rows in the supplied sequence of DataRow objects to the destination table specified by the [`DestinationTableName`](../DestinationTableName/) property of the [`MySqlBulkCopy`](../../MySqlBulkCopyType/) object. The number of columns to be read from the DataRow objects must be specified in advance.

```csharp
public ValueTask WriteToServerAsync(IEnumerable<DataRow> dataRows, int columnCount, 
    CancellationToken cancellationToken = default(CancellationToken))
```

| parameter | description |
| --- | --- |
| dataRows | The collection of DataRow objects. |
| columnCount | The number of columns to copy (in each row). |
| cancellationToken | A token to cancel the asynchronous operation. |

## See Also

* class [MySqlBulkCopy](../../MySqlBulkCopyType/)
* namespace [MySqlConnector](../../MySqlBulkCopyType/)
* assembly [MySqlConnector](../../../MySqlConnectorAssembly/)

<!-- DO NOT EDIT: generated by xmldocmd for MySqlConnector.dll -->
