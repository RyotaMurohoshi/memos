package com.mrstar.delegated_propety_example

import kotlin.properties.ReadWriteProperty
import kotlin.reflect.KProperty

class IntRestrictedProperty(val minValue:Int, val maxValue:Int, initValue:Int = 0) : ReadWriteProperty<Any?, Int> {
    var intValue = initValue

    override fun getValue(thisRef: Any?, prop: KProperty<*>): Int = intValue

    override fun setValue(thisRef: Any?, prop: KProperty<*>, value: Int) {
        intValue = clamp(value)
    }

    fun clamp (value:Int) : Int =
            if (value < minValue) {
                minValue
            } else if (value > maxValue){
                maxValue
            } else {
                value
            }
}

class ExamResult(val subject:String) {
    var point: Int by IntRestrictedProperty(minValue = 0, maxValue = 100)

    override fun toString(): String = "${subject} : ${point}"
}

fun main(args: Array<String>) {
    val japanese = ExamResult("国語")
    japanese.point = -10
    println(japanese) // 国語 : 100

    val english = ExamResult("英語")
    english.point = 110
    println(english) // 英語 : 0
}