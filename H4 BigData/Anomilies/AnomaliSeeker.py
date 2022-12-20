import pandas as pd

df = pd.read_csv('Anomilies\\anomalisporing.csv')
sorted(df)

tests = [
    [0.20,0.80,0.33],
    [0.25,0.75,0.5],
    [0.25,0.75,1.5],
    [0.24,0.76,1.5]
]

for x in tests:
    print("\n\n------- test --------")
    print(x)
    print("")

    first_quantile = x[0]
    last_quantile = x[1]    
    deviation = x[2]

    q1 = df.quantile(first_quantile)[0]
    q3 = df.quantile(last_quantile)[0]
    IQR = q3 - q1

    lower_range = q3 - 1.5 * IQR
    upper_range = q1 + 1.5 * IQR

    outliers = df[(df < lower_range) | (df > upper_range)]

    no_nans = outliers[~outliers.isnull().any(axis=1)]

    print(no_nans.to_string())
