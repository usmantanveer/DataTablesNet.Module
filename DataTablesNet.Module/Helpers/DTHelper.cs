using System;
using System.Collections.Generic;
using System.Linq;

namespace DataTablesNet.Module.Helpers {
    public class DTHelper {
        public DTHelper() {
        }

        public static IEnumerable<T> Sort<T>(IEnumerable<T> data, DTRequest request) {
            IOrderedEnumerable<T> sortedData = data.OrderBy(d => 1);
            foreach (var order in request.Order) {
                var propertyName = request.Columns[order.Column].Name;
                if (string.IsNullOrWhiteSpace(propertyName)) {
                    continue;
                }

                var property = typeof(T).GetProperty(propertyName);
                if (property == null) {
                    continue;
                }

                if (order.Dir.Equals("asc", StringComparison.InvariantCultureIgnoreCase)) {
                    sortedData = sortedData.ThenBy(d => property.GetValue(d));
                }
                else {
                    sortedData = sortedData.ThenByDescending(d => property.GetValue(d));
                }
            }

            return sortedData;
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> data, DTRequest request, out int recordsFiltered) {
            IEnumerable<T> filteredData = data;
            recordsFiltered = filteredData.Count();

            if (string.IsNullOrWhiteSpace(request.Search.Value)) {
                return data;
            }

            filteredData = data.Where(d => d.ToString().IndexOf(request.Search.Value) > -1);
            recordsFiltered = filteredData.Count();
            return filteredData;
        }

        public static IEnumerable<T> Page<T>(IEnumerable<T> data, DTRequest request) {
            return data.Skip(request.Start).Take(request.Length);
        }

        public static IEnumerable<T> PrepareResult<T>(IEnumerable<T> data, DTRequest request, out int totalRecords, out int recordsFiltered) {
            totalRecords = data.Count();

            IEnumerable<T> result = data;
            result = Sort(result, request);
            result = Filter(result, request, out recordsFiltered);
            result = Page(result, request);

            return result;
        }
    }
}

