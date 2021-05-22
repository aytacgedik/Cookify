import { StatusBar } from 'expo-status-bar';
import React from 'react';
import { StyleSheet, TouchableOpacity, Text, View, FlatList, SafeAreaView } from 'react-native';

const Data = [
  {
    id: '1',
    title: 'Cooks',
    destination: 'CooksList'
  },
  {
    id: '2',
    title: 'Ingredients',
    destination: 'IngredientsList'
  },
  {
    id: '3',
    title: 'Recipes',
    destination: 'RecipesList'
  }
];


export default function StartPage({navigation}) {
  return (
    <SafeAreaView style={styles.container}>
      <FlatList
        data={Data}
        renderItem = {({item}) => (
          <TouchableOpacity onPress={()=>navigation.navigate(item.destination)}>
            <View style = {styles.item}>
              <Text style={styles.title}>{item.title}</Text>
            </View>
          </TouchableOpacity>
        )}
        keyExtractor = {item => item.id}
      />
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    marginTop: StatusBar.currentHeight || 0
  },
  
  item: {
    backgroundColor: '#8B4513',
    padding: 20,
    marginVertical: 50,
    marginHorizontal: 16,
  },
  title: {
    fontSize: 24,
    color: '#FFFFFF',
    textAlign: 'center'
  },
});