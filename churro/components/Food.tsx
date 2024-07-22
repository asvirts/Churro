import React, { useEffect, useState } from "react"
import { ActivityIndicator, FlatList, View } from "react-native"

type Food = {
  fdcId: Number
  description: String
  publicationDate: Date
}

export default function GetAllFoods() {
  const [isLoading, setLoading] = useState(true)
  const [data, setData] = useState<Food[]>([])

  const getFoodsFromApiAsync = async () => {
    try {
      const response = await fetch(
        "https://api.nal.usda.gov/fdc/v1/foods/list?api_key=v9bpP0Jnf8AFmrgmYGe6DwHfHjbU2aIei8cmlJcR"
      )
      const json = await response.json()
      setData(json.description)
    } catch (error) {
      console.error(error)
    }
  }

  useEffect(() => {
    GetAllFoods()
  }, [])

  return (
    <View style={{ flex: 1, padding: 24 }}>
      {isLoading ? (
        <ActivityIndicator />
      ) : (
        <FlatList
          data={data}
          keyExtractor={(item) => item.fdcId.toString()}
          renderItem={({ item }) => (
            <Text>
              {item.description}, {item.publicationDate}
            </Text>
          )}
        />
      )}
    </View>
  )
}
