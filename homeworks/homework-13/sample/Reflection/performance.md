
| Method                           | Mean          | StdErr        | StdDev        | Median        | Scaled       | Scaled-StdDev | Gen 0 | Bytes Allocated/Op |
|----------------------------------|---------------|---------------|---------------|---------------|--------------|----------------|-------|---------------------|
| GetViaProperty                   | 0.2159 ns     | 0.0047 ns     | 0.0183 ns     | 0.2143 ns     | 1.00         | 0.00           | -     | 0.00                |
| GetViaDelegate                   | 1.8903 ns     | 0.0082 ns     | 0.0306 ns     | 1.8830 ns     | 8.82         | 0.74           | -     | 0.00                |
| GetViaILEmit                     | 2.9236 ns     | 0.0067 ns     | 0.0261 ns     | 2.9189 ns     | 13.64        | 1.12           | -     | 0.00                |
| GetViaCompiledExpressionTrees    | 12.3623 ns    | 0.0200 ns     | 0.0776 ns     | 12.3536 ns    | 57.65        | 4.74           | -     | 0.00                |
| GetViaReflectionWithCaching      | 125.3878 ns   | 0.2017 ns     | 0.6987 ns     | 125.4703 ns   | 584.78       | 48.06          | -     | 0.00                |
| GetViaReflection                 | 197.9258 ns   | 0.2704 ns     | 1.0473 ns     | 197.6979 ns   | 923.08       | 75.85          | -     | 0.01                |
| GetViaDelegateDynamicInvoke      | 842.9131 ns   | 1.2649 ns     | 4.8991 ns     | 842.7109 ns   | 3,931.17     | 323.14         | 440.00| 419.04              |


| Method                           | Mean          | StdErr        | StdDev        | Median        | Scaled       | Scaled-StdDev | Gen 0 | Bytes Allocated/Op |
|----------------------------------|---------------|---------------|---------------|---------------|--------------|----------------|-------|---------------------|
| SetViaProperty                   | 1.4043 ns     | 0.0200 ns     | 0.0776 ns     | 1.3699 ns     | 6.55         | 0.64           | -     | 0.00                |
| SetViaDelegate                   | 2.8215 ns     | 0.0078 ns     | 0.0302 ns     | 2.8184 ns     | 13.16        | 1.09           | -     | 0.00                |
| SetViaILEmit                     | 2.8226 ns     | 0.0061 ns     | 0.0227 ns     | 2.8216 ns     | 13.16        | 1.08           | -     | 0.00                |
| SetViaCompiledExpressionTrees    | 10.7329 ns    | 0.0221 ns     | 0.0827 ns     | 10.7111 ns    | 50.06        | 4.12           | -     | 0.00                |
| SetViaReflectionWithCaching      | 214.4321 ns   | 0.3122 ns     | 1.2092 ns     | 214.3265 ns   | 1,000.07     | 82.19          | 104.00| 98.49               |
| SetViaReflection                 | 287.1039 ns   | 0.3288 ns     | 1.1855 ns     | 287.2946 ns   | 1,338.99     | 109.94         | 122.20| 115.63              |
| SetViaDelegateDynamicInvoke      | 922.4618 ns   | 2.9192 ns     | 10.5253 ns    | 921.0714 ns   | 4,302.17     | 355.96         | 403.87| 390.99              |