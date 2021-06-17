import { StatusBar } from 'expo-status-bar';
import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { createStackNavigator } from '@react-navigation/stack'
import { NavigationContainer } from '@react-navigation/native'

import CooksList from './components/Cooks/CooksList'
import CreateCookView from './components/Cooks/CreateCookView'
import OneCookView from './components/Cooks/OneCookView'
import UpdateCookView from './components/Cooks/UpdateCookView'

import IngredientsList from './components/Ingredients/IngredientsList'
import OneIngredientView from './components/Ingredients/OneIngredientView'


import RecipesList from './components/Recipes/RecipesList'
import OneRecipeView from './components/Recipes/OneRecipeView'
import CreateRecipeView from './components/Recipes/CreateRecipeView'
import UpdateRecipeView from './components/Recipes/UpdateRecipeView'

import StartPage from './components/StartPage'
const Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer style={styles.container}>
      <Stack.Navigator initialRouteName="StartPage">
        <Stack.Screen name = "StartPage" component={StartPage}/>

        <Stack.Screen name = "CooksList" component={CooksList} />
        <Stack.Screen name = "Cook">
          {props => <OneCookView {...props}/>}
        </Stack.Screen>
        <Stack.Screen name = "CreateCook">
          {props => <CreateCookView {...props}/>}
        </Stack.Screen>
        <Stack.Screen name = "UpdateCook">
          {props => <UpdateCookView {...props}/>}
        </Stack.Screen>



        <Stack.Screen name = "IngredientsList" component={IngredientsList} />
        <Stack.Screen name = "Ingredient">
          {props => <OneIngredientView {...props}/>}
        </Stack.Screen>

        <Stack.Screen name = "RecipesList" component={RecipesList} />
        <Stack.Screen name = "Recipe">
          {props => <OneRecipeView {...props}/>}
        </Stack.Screen>
        <Stack.Screen name = "CreateRecipe">
          {props => <CreateRecipeView {...props}/>}
        </Stack.Screen>
        <Stack.Screen name = "UpdateRecipe">
          {props => <UpdateRecipeView {...props}/>}
        </Stack.Screen>


      </Stack.Navigator> 
    </NavigationContainer>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
